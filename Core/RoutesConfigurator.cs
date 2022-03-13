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
            app.MapPost("/", this.GameHandler.SaveGameAsync);
            app.MapGet("/game/get/{id}", this.GameHandler.GetGame);
        }
    }
}
