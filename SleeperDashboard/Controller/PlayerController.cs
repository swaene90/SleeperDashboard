using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SleeperDashboard.Data;
using SleeperDashboard.Dto.Player;

namespace SleeperDashboard.Controller;

[ApiController]
[Route("[controller]")]
public class PlayerController(
    ILogger<PlayerController> logger,
    IMediator mediator,
    SleeperDbContext context) : ControllerBase
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
        request.RequestUri = new Uri($"https://api.sleeper.app/v1/players/nfl/");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "*/*");
        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        var playersDict = JsonSerializer.Deserialize<Dictionary<string, Player>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var existingPlayersIds = await _context.Players.Select(p => p.Id.ToString()).ToListAsync();

        foreach (var player in playersDict)
        {
            var playerEntity = new Data.Entity.Player()
            {
                Id = player.Key,
                Hashtag = player.Value.Hashtag,
                DepthChartPosition = player.Value.DepthChartPosition,
                Status = player.Value.Status,
                Sport = player.Value.Sport,
                Number = player.Value.Number ?? 0,
                SearchLastName = player.Value.SearchLastName,
                InjuryStartDate = player.Value.InjuryStartDate as DateTime?,
                Weight = player.Value.Weight,
                Position = player.Value.Position,
                PracticeParticipation = player.Value.PracticeParticipation as bool?,
                SportradarId = player.Value.SportradarId,
                Team = player.Value.Team,
                LastName = player.Value.LastName,
                College = player.Value.College,
                FantasyDataId = player.Value.FantasyDataId,
                InjuryStatus = player.Value.InjuryStatus as string,
                PlayerId = player.Value.PlayerId,
                Height = player.Value.Height,
                SearchFullName = player.Value.SearchFullName,
                Age = player.Value.Age ?? 0,
                StatsId = player.Value.StatsId,
                BirthCountry = player.Value.BirthCountry,
                EspnId = player.Value.EspnId,
                SearchRank = player.Value.SearchRank,
                FirstName = player.Value.FirstName,
                DepthChartOrder = player.Value.DepthChartOrder,
                YearsExp = player.Value.YearsExp,
                RotowireId = player.Value.RotowireId as string,
                RotoworldId = player.Value.RotoworldId,
                SearchFirstName = player.Value.SearchFirstName,
                YahooId = player.Value.YahooId as string
            };

            if (existingPlayersIds.Contains(player.Key))
            {
                _context.Players.Update(playerEntity);
            }
            else
            {
                _context.Players.Add(playerEntity);
            }
        }

        await _context.SaveChangesAsync();
        return Ok();
    }
}
