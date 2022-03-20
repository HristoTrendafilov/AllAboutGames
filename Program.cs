using AllAboutGames.Core;
using AllAboutGames.Core.Middlewares;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System.Text;

var builder = WebApplication.CreateBuilder();
DependencyManager.RegisterDependencies(builder);

builder.Services.AddDbContext<AllAboutGamesDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    //.EnableSensitiveDataLogging();
});

Enum.TryParse(builder.Configuration["Serilog:LogLevel"], out LogEventLevel minimumLevel);
Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .MinimumLevel.Is(minimumLevel)
  .WriteTo.Logger(lc =>
  {
      lc.Filter.ByIncludingOnly(logEvent => logEvent.Exception != null)
        .WriteTo.File(new JsonFormatter(), builder.Configuration["Serilog:ExceptionsPath"],
        rollingInterval: RollingInterval.Day,
        encoding: Encoding.UTF8);
  })
  .WriteTo.Logger(lc =>
  {
      lc.WriteTo.File(builder.Configuration["Serilog:LogPath"],
          rollingInterval: RollingInterval.Day,
          encoding: Encoding.UTF8);
  })
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

var app = builder.Build();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<GatewayProtocolMiddleware>();
app.UseHttpsRedirection();

app.Run();