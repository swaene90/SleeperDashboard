namespace SleeperDashboard.Client.Sleeper
{
    public class SleeperClient : ISleeperClient
    {
        private readonly HttpClient _httpClient;
        public SleeperClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Sleeper");
        }

        public async Task<HttpResponseMessage> GetAsync(HttpRequestMessage message)
        {
            return await _httpClient.SendAsync(message);
        }
    }
}
