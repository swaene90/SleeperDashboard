using System.ComponentModel.DataAnnotations;

namespace SleeperDashboard.Data.Entity
{
    public class Configuration
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Value { get; set; }
    }
}
