using AllAboutGames.Core;
using AllAboutGames.Data.DataContext;
using AllAboutGames.Handlers;
using AllAboutGames.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<RoutesConfigurator>();
builder.Services.AddTransient<GameHandler>();
builder.Services.AddTransient<GameService>();
builder.Services.AddTransient<HelloHandler>();

builder.Services.AddDbContext<AllAboutGamesDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"));
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var serviceScope = app.Services.CreateScope().ServiceProvider;
var routesConfigurator = serviceScope.GetRequiredService<RoutesConfigurator>();
routesConfigurator.Configure(app);

app.UseHttpsRedirection();
app.Run();