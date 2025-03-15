
namespace SleeperDashboard.Client
{
    public interface IChatGPTClient
    {
        Task<HttpResponseMessage> PostAsync(HttpRequestMessage httpRequestMessage);
    }
}