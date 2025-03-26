using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using MySqlX.XDevAPI;
using SleeperDashboard.Client.AI;
using System.Text.Json;

namespace SleeperDashboard.Application.AIPrompt
{
    public class ChatGPTPromptQueryHandler : IRequestHandler<ChatGPTPromptQuery, ChatGPTPromptQueryResponse>
    {
        private readonly IChatGPTClient _client;
        private readonly ILogger<ChatGPTPromptQueryHandler> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IChatCompletionService chatCompletionService;
        private readonly Kernel kernel;
        private const string _baseUrl = "/v1/chat/completions";

        public ChatGPTPromptQueryHandler(
            IChatGPTClient client,
            ILogger<ChatGPTPromptQueryHandler> logger,
            IMemoryCache memoryCache,
            IChatCompletionService chatCompletionService,
            Kernel kernel)
        {
            _client = client;
            _logger = logger;
            _memoryCache = memoryCache;
            this.chatCompletionService = chatCompletionService;
            this.kernel = kernel;
        }

        public async Task<ChatGPTPromptQueryResponse> Handle(ChatGPTPromptQuery request, CancellationToken cancellationToken)
        {
            Dictionary<Tuple<int, AuthorRole>, List<string>>? userChatHistory = _memoryCache.TryGetValue("UserChatHistory", out Dictionary<Tuple<int, AuthorRole>, List<string>>? cacheValue)
                ? cacheValue : [];

            userChatHistory = userChatHistory ?? [];

            var userTuple = new Tuple<int, AuthorRole>(request.UserId, AuthorRole.User);

            if (userChatHistory.ContainsKey(userTuple))
            {
                if (userChatHistory[userTuple] == null)
                {
                    userChatHistory[userTuple] = [request.Prompt];
                }
                else
                {
                    userChatHistory[userTuple].Add(request.Prompt);
                }
            }
            else
            {
                userChatHistory.Add(userTuple, [request.Prompt]);
            }

            ChatHistory history = new();
            foreach (var chat in userChatHistory[userTuple])
            {
                history.AddUserMessage(chat);
            }

            OpenAIPromptExecutionSettings settings = new()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };

            var result = await chatCompletionService.GetChatMessageContentAsync(history, settings, kernel);

            var assisstantTuple = new Tuple<int, AuthorRole>(request.UserId, AuthorRole.Assistant);

            if (userChatHistory.ContainsKey(assisstantTuple))
            {
                if (userChatHistory[assisstantTuple] == null)
                {
                    userChatHistory[assisstantTuple] = [result.Content];
                }
                else
                {
                    userChatHistory[assisstantTuple].Add(result.Content);
                }
            }
            else
            {
                userChatHistory.Add(assisstantTuple, [result.Content]);
            }

            _memoryCache.Set("UserChatHistory", userChatHistory);

            return new ChatGPTPromptQueryResponse
            {
                Response = result
            };

            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _baseUrl);
            ////httpRequestMessage.Headers.Add("Content-Type", "application/json");

            //httpRequestMessage.Content = JsonContent.Create(new
            //{
            //    model = "deepseek-chat",
            //    messages = new List<object>
            //    {
            //        new
            //        {
            //            role = "system",
            //            content = "You are an expert in fantasy football"
            //        },
            //        new
            //        {
            //            role = "user",
            //            content = request.Prompt
            //        }
            //    }.ToArray(),
            //    stream = false
            //});

            //var response = await _client.PostAsync(httpRequestMessage);

            //if (response.IsSuccessStatusCode)
            //{
            //    var responseContent = await response.Content.ReadAsStreamAsync();
            //    return new ChatGPTPromptQueryResponse
            //    {
            //        Response = await JsonSerializer.DeserializeAsync<object>(responseContent, cancellationToken: cancellationToken)
            //    };
            //}
            //else
            //{
            //    _logger.LogError($"Failed to get a response from the ChatGPT API. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, Content: {await response.Content.ReadAsStringAsync()}");
            //    throw new Exception("Failed to get a response from the ChatGPT API.");
            //}
        }
    }
}
