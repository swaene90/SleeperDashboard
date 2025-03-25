using MediatR;
using Newtonsoft.Json;
using SleeperDashboard.Client.Sleeper;
using SleeperDashboard.Data;
using SleeperDashboard.Helper;
using SleeperDashboard.Model.Roster;

namespace SleeperDashboard.Application.GetRoster
{
    public class GetRosterQueryHandler(
        LeagueInfo leagueInfo,
        ISleeperClient sleeperClient,
        SleeperDbContext context) : IRequestHandler<GetRosterQuery, GetRosterQueryResponse>
    {
        private readonly LeagueInfo _leagueInfo = leagueInfo;
        private readonly ISleeperClient _sleeperClient = sleeperClient;
        private readonly SleeperDbContext _context = context;

        public async Task<GetRosterQueryResponse> Handle(GetRosterQuery request, CancellationToken cancellationToken)
        {
            var queryResponse = new GetRosterQueryResponse();

            var response = await _sleeperClient.GetAsync(new HttpRequestMessage(HttpMethod.Get, $"/v1/league/{_leagueInfo.Id}/rosters"));
            var result = await response.Content.ReadAsStringAsync(cancellationToken);

            queryResponse.Roster = JsonConvert.DeserializeObject<IEnumerable<Roster>>(result);

            return queryResponse;
        }
    }
}
