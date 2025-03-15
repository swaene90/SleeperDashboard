using MediatR;
using Microsoft.AspNetCore.Mvc;
using SleeperDashboard.Application;

namespace SleeperDashboard.Controller
{
    public class AIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("query")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetQuery(string prompt)
        {
            return Ok(await _mediator.Send(new ChatGPTPromptQuery() { Prompt = prompt }));
        }
    }
}
