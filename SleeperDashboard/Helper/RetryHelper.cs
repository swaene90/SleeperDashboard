namespace SleeperDashboard.Helper
{
    public static class RetryHelper
    {
        public static async Task<T> Retry<T>(Func<Task<T>> action, int maxRetries = 3)
        {
            var attempts = 0;
            while (true)
            {
                try
                {
                    await Task.Delay(1000);
                    return await action();
                }
                catch (Exception ex)
                {
                    attempts++;
                    if (attempts == maxRetries)
                    {
                        throw;
                    }
                }
            }
        }

        public static async Task Retry(Func<Task> action, int maxRetries = 3)
        {
            var attempts = 0;
            while (true)
            {
                try
                {
                    await action();
                    return;
                }
                catch (Exception ex)
                {
                    attempts++;
                    if (attempts == maxRetries)
                    {
                        throw;
                    }
                    await Task.Delay(attempts * 1000);

                }
            }
        }
    }
}
