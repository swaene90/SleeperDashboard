using SleeperDashboard.Dto.Player;

namespace SleeperDashboard.Application.GetPlayers
{
    public class GetPlayersQueryResponse
    {
        public Dictionary<string, Player> Players { get; set; }
    }
}
