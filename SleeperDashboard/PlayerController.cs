using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SleeperDashboard.Data;
using SleeperDashboard.Dto.Player;

namespace SleeperDashboard;

[ApiController]
[Route("[controller]")]
public class PlayerController(ILogger<PlayerController> logger, IMediator mediator, SleeperDbContext context) : ControllerBase
{
    private readonly ILogger<PlayerController> _logger = logger;
    private readonly IMediator _mediator = mediator;
    private readonly SleeperDbContext _context = context;

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

    [HttpGet]
    [Route("player")]
    public async Task<IActionResult> GetPlayers()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri($"https://api.sleeper.app/v1/players/nfl/6462");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.com)");
        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var players = JsonSerializer.Deserialize<IEnumerable<Player>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        foreach (var player in players)
        {
            var playerEntity = new Data.Entity.Player()
            {
                Id = player.Id,
                Hashtag = player.Details.Hashtag,
                DepthChartPosition = player.Details.DepthChartPosition,
                Status = player.Details.Status,
                Sport = player.Details.Sport,
                Number = player.Details.Number,
                SearchLastName = player.Details.SearchLastName,
                InjuryStartDate = player.Details.InjuryStartDate as DateTime?,
                Weight = player.Details.Weight,
                Position = player.Details.Position,
                PracticeParticipation = player.Details.PracticeParticipation as bool?,
                SportradarId = player.Details.SportradarId,
                Team = player.Details.Team,
                LastName = player.Details.LastName,
                College = player.Details.College,
                FantasyDataId = player.Details.FantasyDataId,
                InjuryStatus = player.Details.InjuryStatus as string,
                PlayerId = player.Details.PlayerId,
                Height = player.Details.Height,
                SearchFullName = player.Details.SearchFullName,
                Age = player.Details.Age,
                StatsId = player.Details.StatsId,
                BirthCountry = player.Details.BirthCountry,
                EspnId = player.Details.EspnId,
                SearchRank = player.Details.SearchRank,
                FirstName = player.Details.FirstName,
                DepthChartOrder = player.Details.DepthChartOrder,
                YearsExp = player.Details.YearsExp,
                RotowireId = player.Details.RotowireId as string,
                RotoworldId = player.Details.RotoworldId,
                SearchFirstName = player.Details.SearchFirstName,
                YahooId = player.Details.YahooId as string
            };

            _context.Players.Add(playerEntity);
        }

        return Ok(players);
    }
}