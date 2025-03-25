using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SleeperDashboard.Client.Sleeper;
using SleeperDashboard.Data;
using SleeperDashboard.Helper;
using SleeperDashboard.Model.Player;

namespace SleeperDashboard.Application.GetPlayers
{
    public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, GetPlayersQueryResponse>
    {
        private readonly ISleeperClient _sleeperClient;
        private readonly SleeperDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        private JsonSerializerSettings _jsonSerializerSettings => new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public GetPlayersQueryHandler(ISleeperClient sleeperClient, SleeperDbContext dbContext, IMediator mediator, IMemoryCache memoryCache)
        {
            _sleeperClient = sleeperClient;
            _dbContext = dbContext;
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<GetPlayersQueryResponse> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var queryResult = new GetPlayersQueryResponse();

            if (_memoryCache.TryGetValue("Players", out IEnumerable<Player>? cacheValue))
            {
                if (cacheValue != null)
                {
                    queryResult.Players = cacheValue;
                    return queryResult;
                }
            }

            if (!await _mediator.Send(new CheckPlayerCacheQuery()))
            {

                var response = await _sleeperClient.GetAsync(new HttpRequestMessage(HttpMethod.Get, "/v1/players/nfl"));
                var result = await response.Content.ReadAsStringAsync(cancellationToken);
                var playersDict = JsonConvert.DeserializeObject<Dictionary<string, Player>>(result, _jsonSerializerSettings);


                if (response.IsSuccessStatusCode && playersDict != null)
                {
                    var players = playersDict.Select(pd =>
                    {
                        var player = pd.Value;
                        player.Id = pd.Key;
                        return player;
                    }).ToList();

                    var dbPlayers = _dbContext.Players.ToList();

                    foreach (var player in players)
                    {
                        var existingPlayer = dbPlayers.FirstOrDefault(p => p.PlayerId == player.Id);
                        if (existingPlayer != null)
                        {
                            existingPlayer = player.ToEntity();
                            _dbContext.Players.Update(existingPlayer);
                        }
                        else
                        {
                            var newPlayer = player.ToEntity();
                            _dbContext.Players.Add(newPlayer);
                        }
                    }

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    queryResult.Players = players;
                    _memoryCache.Set("Players", players, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
                    });
                }
                else
                {
                    queryResult.Players = [];
                }
            }
            else
            {
                queryResult.Players = await _dbContext.Players.Select(p => p.ToModel()).ToListAsync(cancellationToken: cancellationToken);
                _memoryCache.Set("Players", queryResult.Players, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
                });
            }

            return queryResult;
        }
    }
}
