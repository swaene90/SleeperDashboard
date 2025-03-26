using MediatR;
using Microsoft.EntityFrameworkCore;
using SleeperDashboard.Data;
using SleeperDashboard.Data.Entity;

namespace SleeperDashboard.Application
{
    public class CheckPlayerCacheQueryHandler : IRequestHandler<CheckPlayerCacheQuery, bool>
    {
        private readonly SleeperDbContext _dbContext;

        public CheckPlayerCacheQueryHandler(SleeperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CheckPlayerCacheQuery request, CancellationToken cancellationToken)
        {
            var isCached = false;

            int? daysToCache = int.TryParse((await _dbContext.Configurations.FirstOrDefaultAsync(c => c.Name == "DaysToCache"))?.Value, out var result) ? result : null;

            if (daysToCache == null)
            {
                daysToCache = 7; // Default to 7 days if not set
            }

            var lastCacheDate = _dbContext.Configurations.FirstOrDefault(c => c.Name == "LastCacheDate");

            if (lastCacheDate == null)
            {
                lastCacheDate = new Configuration
                {
                    Name = "LastCacheDate",
                    Value = DateTime.UtcNow.ToString("yyyy-MM-dd")
                };

                _dbContext.Configurations.Add(lastCacheDate);
            }
            else
            {
                var lastCacheDateValue = DateTime.Parse(lastCacheDate.Value);
                if (lastCacheDateValue.AddDays(daysToCache.Value) < DateTime.UtcNow)
                {
                    lastCacheDate.Value = DateTime.UtcNow.ToString("yyyy-MM-dd");
                    _dbContext.Configurations.Update(lastCacheDate);
                }
                else
                {
                    isCached = true;
                }
            }

            return isCached;
        }
    }
}
