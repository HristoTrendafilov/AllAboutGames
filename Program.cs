using AllAboutGames.Core;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;
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

var loggingSwitch = new LoggingLevelSwitch();
Enum.TryParse(builder.Configuration["Serilog:LogLevel"], out LogEventLevel minimumLevel);
loggingSwitch.MinimumLevel = minimumLevel;

Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .MinimumLevel.ControlledBy(loggingSwitch)
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GatewayProtocolMiddleware>();

app.UseHttpsRedirection();

app.Run();