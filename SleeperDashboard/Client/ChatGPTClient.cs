using SleeperDashboard.Helper;

namespace SleeperDashboard.Client
{
    public class ChatGPTClient : IChatGPTClient
    {
        private readonly HttpClient _httpClient;

        public ChatGPTClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OpenAI");
        }

        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage httpRequestMessage)
        {
            return await _httpClient.SendAsync(httpRequestMessage);
        }
    }
}
