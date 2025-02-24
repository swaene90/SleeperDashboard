using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SleeperDashboard.Data.Entity
{
    [PrimaryKey(nameof(Id))]
    public class Player
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string? Hashtag { get; set; }
        public int DepthChartPosition { get; set; }
        
        [MaxLength(255)]
        public string? Status { get; set; }
        
        [MaxLength(255)]
        public string? Sport { get; set; }
        public List<FantasyPosition>? FantasyPositions { get; set; }
        public int Number { get; set; }
        
        [MaxLength(255)]
        public string? SearchLastName { get; set; }
        public DateTime? InjuryStartDate { get; set; }
        
        [MaxLength(255)]
        public string? Weight { get; set; }
        
        [MaxLength(255)]
        public string? Position { get; set; }
        public bool? PracticeParticipation { get; set; }
        
        [MaxLength(255)]
        public string? SportradarId { get; set; }
        
        [MaxLength(255)]
        public string? Team { get; set; }
        
        [MaxLength(255)]
        public string? LastName { get; set; }
        
        [MaxLength(255)]
        public string? College { get; set; }
        public int FantasyDataId { get; set; }
        
        [MaxLength(255)]
        public string? InjuryStatus { get; set; }
        
        [MaxLength(255)]
        public string? PlayerId { get; set; }
        
        [MaxLength(255)]
        public string? Height { get; set; }
        
        [MaxLength(255)]
        public string? SearchFullName { get; set; }
        public int Age { get; set; }
        
        [MaxLength(255)]
        public string? StatsId { get; set; }
        
        [MaxLength(255)]
        public string? BirthCountry { get; set; }
        
        [MaxLength(255)]
        public string? EspnId { get; set; }
        public int SearchRank { get; set; }
        
        [MaxLength(255)]
        public string? FirstName { get; set; }
        public int DepthChartOrder { get; set; }
        public int YearsExp { get; set; }
        
        [MaxLength(255)]
        public string? RotowireId { get; set; }
        public int RotoworldId { get; set; }
        
        [MaxLength(255)]
        public string? SearchFirstName { get; set; }
        
        [MaxLength(255)]
        public string? YahooId { get; set; }
    }
}
