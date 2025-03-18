using MediatR;
using MySqlX.XDevAPI;
using SleeperDashboard.Client.AI;
using System.Text.Json;

namespace SleeperDashboard.Application.AIPrompt
{
    public class ChatGPTPromptQueryHandler : IRequestHandler<ChatGPTPromptQuery, ChatGPTPromptQueryResponse>
    {
        private readonly IChatGPTClient _client;
        private readonly ILogger<ChatGPTPromptQueryHandler> _logger;
        private const string _baseUrl = "/v1/chat/completions";

        public ChatGPTPromptQueryHandler(IChatGPTClient client, ILogger<ChatGPTPromptQueryHandler> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ChatGPTPromptQueryResponse> Handle(ChatGPTPromptQuery request, CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _baseUrl);
            //httpRequestMessage.Headers.Add("Content-Type", "application/json");
       
            httpRequestMessage.Content = JsonContent.Create(new
            {
                model = "deepseek-chat",
                messages = new List<object>
                {
                    new
                    {
                        role = "system",
                        content = "You are an expert in fantasy football"
                    },
                    new
                    {
                        role = "user",
                        content = request.Prompt
                    }
                }.ToArray(),
                stream = false
            });

            var response = await _client.PostAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStreamAsync();
                return new ChatGPTPromptQueryResponse
                {
                    Response = await JsonSerializer.DeserializeAsync<object>(responseContent, cancellationToken: cancellationToken)
                };
            }
            else
            {
                _logger.LogError($"Failed to get a response from the ChatGPT API. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, Content: {await response.Content.ReadAsStringAsync()}");
                throw new Exception("Failed to get a response from the ChatGPT API.");
            }
        }
    }
}
