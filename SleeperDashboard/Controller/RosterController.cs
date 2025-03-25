using MediatR;
using Microsoft.AspNetCore.Mvc;
using SleeperDashboard.Application.GetRoster;
using SleeperDashboard.Helper;

namespace SleeperDashboard.Controller
{
    public class RosterController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("roster")]
        public async Task<IActionResult> GetRoster(string rosterId)
        {
            var roster = await _mediator.Send(new GetRosterQuery());
            return Ok(roster);
        }
    }
}
