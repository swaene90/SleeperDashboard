using MediatR;

namespace SleeperDashboard.Application.AIPrompt
{
    public class ChatGPTPromptQuery : IRequest<ChatGPTPromptQueryResponse>
    {
        public string? Prompt { get; set; }
    }
}
