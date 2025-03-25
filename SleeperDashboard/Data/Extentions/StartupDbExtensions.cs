using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SleeperDashboard.Helper;

namespace SleeperDashboard.Data.Extentions
{
    public static class StartupDbExtensions
    {
        public static async Task CreateIfNotExists(this IHost host)
        {

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<SleeperDbContext>();

            var _logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                _logger.LogInformation("Attempting to connect to database...");
                await context.Database.OpenConnectionAsync();
                _logger.LogInformation("Database connection successful!");

                var databaseCreate = context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (databaseCreate != null)
                {
                    if (!await databaseCreate.CanConnectAsync())
                    {
                        await databaseCreate.CreateAsync();
                        _logger.LogInformation("Database created for: {name}", nameof(SleeperDbContext));
                    }
                    
                    if (!await databaseCreate.HasTablesAsync())
                    {
                        await databaseCreate.CreateTablesAsync();
                        _logger.LogInformation("Database tables created for: {name}", nameof(SleeperDbContext));

                    }

                    //await InitializeSeedData.Initialize(context);
                    //_logger.LogInformation("Database seeded for: {name}", nameof(SleeperDbContext));

                    //_logger.LogInformation("Database already exists for: {name}, starting migration", nameof(SleeperDbContext));
                    //await context.Database.MigrateAsync();
                    //_logger.LogInformation("Database migration complete for: {name}", nameof(SleeperDbContext));
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred creating the DB.");
                throw;
            }
        }
    }
}
