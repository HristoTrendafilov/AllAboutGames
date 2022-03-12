using AllAboutGames.Core;
using AllAboutGames.Data.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
DependencyManager.RegisterDependencies(builder);

builder.Services.AddDbContext<AllAboutGamesDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
    .EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(typeof(Program));
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