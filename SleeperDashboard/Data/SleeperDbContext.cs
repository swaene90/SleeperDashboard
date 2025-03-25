using Microsoft.EntityFrameworkCore;

namespace SleeperDashboard.Data
{
    public class SleeperDbContext : DbContext
    {
        public SleeperDbContext(DbContextOptions<SleeperDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Entity.Player> Players { get; set; }
        public DbSet<Entity.FantasyPosition> FantasyPosition { get; set; }
        public DbSet<Entity.Roster> Rosters { get; set; }
        public DbSet<Entity.Metadata> Metadata { get; set; }
        public DbSet<Entity.Configuration> Configurations { get; set; }
        public DbSet<Entity.Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the primary key for the Player entity
            modelBuilder.Entity<Entity.Player>()
                .HasKey(p => p.PlayerId);
            // Configure the primary key for the FantasyPosition entity
            modelBuilder.Entity<Entity.FantasyPosition>()
                .HasKey(fp => fp.Id);
            // Configure the primary key for the Roster entity
            modelBuilder.Entity<Entity.Roster>()
                .HasKey(r => r.RosterId);
            // Configure the primary key for the Metadata entity
            modelBuilder.Entity<Entity.Metadata>()
                .HasKey(m => m.Id);
            // Configure the primary key for the Configuration entity
            modelBuilder.Entity<Entity.Configuration>()
                .HasKey(c => c.Id);
            // Configure the primary key for the Setting entity
            modelBuilder.Entity<Entity.Setting>()
                .HasKey(s => s.Id);
        }
    }
}
