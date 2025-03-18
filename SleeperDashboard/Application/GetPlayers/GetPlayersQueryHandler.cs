using MediatR;
using MySqlX.XDevAPI.Common;
using SleeperDashboard.Client.Sleeper;
using SleeperDashboard.Dto.Player;
using System.Text.Json;

namespace SleeperDashboard.Application.GetPlayers
{
    public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, GetPlayersQueryResponse>
    {
        private readonly ISleeperClient _sleeperClient;
        public GetPlayersQueryHandler(ISleeperClient sleeperClient)
        {
            _sleeperClient = sleeperClient;
        }
        public async Task<GetPlayersQueryResponse> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var queryResult = new GetPlayersQueryResponse();

            var response = await _sleeperClient.GetAsync(new HttpRequestMessage(HttpMethod.Get, "/v1/players/nfl"));
            var result = await response.Content.ReadAsStringAsync();
            var playersDict = JsonSerializer.Deserialize<Dictionary<string, Player>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (response.IsSuccessStatusCode)
            {
                queryResult.Players = playersDict;
            }
            else
            {
                queryResult.Players = new Dictionary<string, Player>();
            }

            return queryResult;
        }
    }
}
