using AllAboutGames.Core;
using AllAboutGames.Core.Gateway;
using AllAboutGames.Core.Handlers;
using AllAboutGames.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using System.Reflection;

var builder = WebApplication.CreateBuilder();

DependencyManager.RegisterDependencies(builder);


builder.Services.AddDbContext<AllAboutGamesDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    //.EnableSensitiveDataLogging();
});

Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .Enrich.WithExceptionDetails()
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