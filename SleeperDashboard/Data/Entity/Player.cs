using Microsoft.EntityFrameworkCore;

namespace SleeperDashboard.Data.Entity.Player
{
    [PrimaryKey(nameof(Id))]
    public class Player
    {
        public int Id { get; set; }
        public string? Hashtag { get; set; }
        public int DepthChartPosition { get; set; }
        public string? Status { get; set; }
        public string? Sport { get; set; }
        public List<string>? FantasyPositions { get; set; }
        public int Number { get; set; }
        public string? SearchLastName { get; set; }
        public object? InjuryStartDate { get; set; }
        public string? Weight { get; set; }
        public string? Position { get; set; }
        public object? PracticeParticipation { get; set; }
        public string? SportradarId { get; set; }
        public string? Team { get; set; }
        public string? LastName { get; set; }
        public string? College { get; set; }
        public int FantasyDataId { get; set; }
        public object? InjuryStatus { get; set; }
        public string? PlayerId { get; set; }
        public string? Height { get; set; }
        public string? SearchFullName { get; set; }
        public int Age { get; set; }
        public string? StatsId { get; set; }
        public string? BirthCountry { get; set; }
        public string? EspnId { get; set; }
        public int SearchRank { get; set; }
        public string? FirstName { get; set; }
        public int DepthChartOrder { get; set; }
        public int YearsExp { get; set; }
        public object? RotowireId { get; set; }
        public int RotoworldId { get; set; }
        public string? SearchFirstName { get; set; }
        public object? YahooId { get; set; }
    }
}
