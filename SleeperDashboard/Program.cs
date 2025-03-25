using SleeperDashboard.Components;
using MySql.EntityFrameworkCore.Extensions;
using SleeperDashboard.Data;
using SleeperDashboard.Data.Extentions;
using SleeperDashboard.Helper;
using SleeperDashboard.Client.AI;
using SleeperDashboard.Client.Sleeper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMySQLServer<SleeperDbContext>(builder.Configuration.GetConnectionString("SleeperMySQL") ?? string.Empty);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddHttpClient("OpenAI", client =>
{
    client.BaseAddress = new Uri("https://api.deepseek.com");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["SLEEPER_DB_API_KEY"]}");
});

builder.Services.AddHttpClient("Sleeper", client =>
{
    client.BaseAddress = new Uri("https://api.sleeper.app");
});


builder.Services.AddTransient<IChatGPTClient, ChatGPTClient>();
builder.Services.AddTransient<ISleeperClient, SleeperClient>();

builder.Services.AddSingleton(new LeagueInfo() { Id = builder.Configuration["LeagueId"] });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sleeper V1");
        options.RoutePrefix = string.Empty; // Swagger at the root URL
    });

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

await RetryHelper.Retry(app.CreateIfNotExists, 10);

app.Run();