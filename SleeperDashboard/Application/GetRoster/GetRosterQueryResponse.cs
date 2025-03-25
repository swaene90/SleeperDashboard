using SleeperDashboard.Model.Roster;

namespace SleeperDashboard.Application.GetRoster
{
    public class GetRosterQueryResponse
    {
        public IEnumerable<Roster>? Roster { get; set; }
    }
}
