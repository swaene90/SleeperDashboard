using MediatR;
using Microsoft.AspNetCore.Mvc;
using SleeperDashboard.Application.AIPrompt;

namespace SleeperDashboard.Controller
{
    public class AIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("query")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuery(int userId, string prompt)
        {
            return Ok(await _mediator.Send(new ChatGPTPromptQuery(userId, prompt)));
        }
    }
}
