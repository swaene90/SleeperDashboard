using SleeperDashboard.Model.Player;

namespace SleeperDashboard.Application.GetPlayers
{
    public class GetPlayersQueryResponse
    {
        public IEnumerable<Player>? Players { get; set; }
    }
}
