using SleeperDashboard.Data.Entity.Player;

namespace SleeperDashboard.Data
{
    public static class InitializeSeedData
    {
        public static async Task Initialize(SleeperDbContext context)
        {
            if (context.Players.Any())
            {
                return;
            }

            var players = new List<Player>
            {
                new Player
                {
                    Id = 3086,
                    Hashtag = "#TomBrady-NFL-NE-12",
                    DepthChartPosition = 1,
                    Status = "Active",
                    Sport = "nfl",
                    FantasyPositions = new List<string> { "QB" },
                    Number = 12,
                    SearchLastName = "brady",
                    InjuryStartDate = null,
                    Weight = "220",
                    Position = "QB",
                    PracticeParticipation = null,
                    SportradarId = "",
                    Team = "NE",
                    LastName = "Brady",
                    College = "Michigan",
                    FantasyDataId = 17836,
                    InjuryStatus = null,
                    PlayerId = "3086",
                    Height = "6'4\"",
                    SearchFullName = "tombrady",
                    Age = 40,
                    StatsId = "",
                    BirthCountry = "United States",
                    EspnId = "",
                    SearchRank = 24,
                    FirstName = "Tom",
                    DepthChartOrder = 1,
                    YearsExp = 14,
                    RotowireId = null,
                    RotoworldId = 8356,
                    SearchFirstName = "tom",
                    YahooId = null
                }
            };

            context.Players.AddRange(players);
            await context.SaveChangesAsync();
        }
    }
}
