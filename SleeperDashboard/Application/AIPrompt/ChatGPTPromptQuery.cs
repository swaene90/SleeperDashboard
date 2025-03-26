using MediatR;

namespace SleeperDashboard.Application.AIPrompt
{
    public class ChatGPTPromptQuery : IRequest<ChatGPTPromptQueryResponse>
    {
        public int UserId { get; }
        public string Prompt { get; }

        public ChatGPTPromptQuery(int userId, string prompt)
        {
            UserId = userId;
            Prompt = prompt;
        }
    }
}
