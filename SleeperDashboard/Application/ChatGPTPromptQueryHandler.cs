using MediatR;
using SleeperDashboard.Client;
using System.Text.Json;

namespace SleeperDashboard.Application
{
    public class ChatGPTPromptQueryHandler : IRequestHandler<ChatGPTPromptQuery, ChatGPTPromptQueryResponse>
    {
        private readonly IChatGPTClient _client;
        private readonly ILogger<ChatGPTPromptQueryHandler> _logger;
        private const string _baseUrl = "v1/chat/completions";

        public ChatGPTPromptQueryHandler(IChatGPTClient client, ILogger<ChatGPTPromptQueryHandler> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<ChatGPTPromptQueryResponse> Handle(ChatGPTPromptQuery request, CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _baseUrl);
            httpRequestMessage.Content = JsonContent.Create(new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = "You are a fantasy football expert."
                    },
                    new
                    {
                        role = "user",
                        content = request.Prompt
                    }
                }
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
