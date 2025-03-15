using MediatR;

namespace SleeperDashboard.Application
{
    public class ChatGPTPromptQuery : IRequest<ChatGPTPromptQueryResponse>
    {
        public string? Prompt { get; set; }
    }
}
