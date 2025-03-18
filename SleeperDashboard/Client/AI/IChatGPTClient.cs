namespace SleeperDashboard.Client.AI
{
    public interface IChatGPTClient
    {
        Task<HttpResponseMessage> PostAsync(HttpRequestMessage httpRequestMessage);
    }
}