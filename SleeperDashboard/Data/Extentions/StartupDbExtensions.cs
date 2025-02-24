using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

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

                    await InitializeSeedData.Initialize(context);
                    _logger.LogInformation("Database seeded for: {name}", nameof(SleeperDbContext));
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
