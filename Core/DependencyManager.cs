using AllAboutGames.Handlers;
using AllAboutGames.Services;

namespace AllAboutGames.Core
{
    public class DependencyManager
    {
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            // Routes
            builder.Services.AddTransient<RoutesConfigurator>();

            // Handlers
            builder.Services.AddTransient<GameHandler>();
            builder.Services.AddTransient<HelloHandler>();

            // Services
            builder.Services.AddTransient<GameService>();
        }
    }
}
