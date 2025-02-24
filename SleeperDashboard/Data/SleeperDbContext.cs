using Microsoft.EntityFrameworkCore;

namespace SleeperDashboard.Data
{
    public class SleeperDbContext : DbContext
    {
        public SleeperDbContext(DbContextOptions<SleeperDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Entity.Player.Player> Players { get; set; }
    }
}
