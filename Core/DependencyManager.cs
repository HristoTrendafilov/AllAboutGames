using AllAboutGames.Handlers;
using AllAboutGames.Services;

namespace AllAboutGames.Core
{
    public class DependencyManager
    {
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            // Routes
            builder.Services.AddScoped<RoutesConfigurator>();

            // Handlers
            builder.Services.AddTransient<GameHandler>();

            // Services
            builder.Services.AddTransient<GameService>();

            // Other
            builder.Services.AddTransient<BaseService>();

        }
    }
}
