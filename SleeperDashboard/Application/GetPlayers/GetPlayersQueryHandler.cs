using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SleeperDashboard.Client.Sleeper;
using SleeperDashboard.Model.Player;

namespace SleeperDashboard.Application.GetPlayers
{
    public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, GetPlayersQueryResponse>
    {
        private readonly ISleeperClient _sleeperClient;

        private JsonSerializerSettings _jsonSerializerSettings => new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public GetPlayersQueryHandler(ISleeperClient sleeperClient)
        {
            _sleeperClient = sleeperClient;
        }

        public async Task<GetPlayersQueryResponse> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var queryResult = new GetPlayersQueryResponse();

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
                });

                queryResult.Players = players;
            }
            else
            {
                queryResult.Players = [];
            }

            return queryResult;
        }
    }
}
