using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SleeperDashboard.Data.Entity
{
    [PrimaryKey(nameof(RosterId))]
    public class Roster
    {
        public string? CoOwners { get; set; }
        public string? Keepers { get; set; }
        public string? LeagueId { get; set; }
        public Metadata Metadata { get; set; }
        public string? OwnerId { get; set; }
        public string? PlayerMap { get; set; }

        public List<Player> Players { get; set; }

        public List<Player> Reserve { get; set; }

        [Key]
        public long RosterId { get; set; }

        public List<Setting> Settings { get; set; }

        public List<Player> Starters { get; set; }
        public string? Taxi { get; set; }
    }
}
