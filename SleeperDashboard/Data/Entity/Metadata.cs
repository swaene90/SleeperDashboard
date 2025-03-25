using System.ComponentModel.DataAnnotations;

namespace SleeperDashboard.Data.Entity
{
    public class Metadata
    {
        [Key]
        public int Id { get; set; }

        public string Record { get; set; }
        public string Streak { get; set; }
        public string AllowPnInactiveStarters { get; set; }
        public string AllowPnPlayerInjuryStatus { get; set; }
        public string AllowPnScoring { get; set; }
        public string RestrictPnScoringStartersOnly { get; set; }
    }
}
