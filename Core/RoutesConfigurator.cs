using AllAboutGames.Handlers;

namespace AllAboutGames.Core
{
    public class RoutesConfigurator
    {
        private readonly HelloHandler HelloHandler;
        private readonly GameHandler GameHandler;

        public RoutesConfigurator(GameHandler gameHandler, HelloHandler helloHandler)
        {
            this.HelloHandler = helloHandler;
            this.GameHandler = gameHandler;
        }

        public void Configure(WebApplication app)
        {
            app.MapGet("/", this.HelloHandler.SayHello);
            app.MapPost("/", this.GameHandler.SaveGame);
        }
    }
}
