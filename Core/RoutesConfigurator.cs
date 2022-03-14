using AllAboutGames.Handlers;
using Serilog;

namespace AllAboutGames.Core
{
    public class RoutesConfigurator
    {
        private readonly GameHandler GameHandler;

        public RoutesConfigurator(GameHandler gameHandler)
        {
            this.GameHandler = gameHandler;
        }

        public void Configure(WebApplication app)
        {
            // Games
            app.MapPost("/Game/Save", this.GameHandler.SaveGameAsync);
            app.MapGet("/Game/Get/{id}", this.GameHandler.GetGame);
        }
    }
}