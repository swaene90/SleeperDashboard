using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SleeperDashboard.Dto.Player;

namespace SleeperDashboard;

[ApiController]
[Route("[controller]")]
public class PlayerController(ILogger<PlayerController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<PlayerController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    private const string Id = "190215971114461472";

    [HttpGet]
    [Route("trending")]
    public async Task<IActionResult> GetTrendingPlayers()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://api.sleeper.app/v1/players/nfl/trending/add?lookback_hours=24&limit=25");
        request.Method = HttpMethod.Get;

        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.com)");

        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var players = JsonSerializer.Deserialize<IEnumerable<TrendingPlayer>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return Ok(players);
    }
}