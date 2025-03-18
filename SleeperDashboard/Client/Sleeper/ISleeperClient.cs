
namespace SleeperDashboard.Client.Sleeper
{
    public interface ISleeperClient
    {
        Task<HttpResponseMessage> GetAsync(HttpRequestMessage message);
    }
}