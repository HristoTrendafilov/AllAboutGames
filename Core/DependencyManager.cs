using AllAboutGames.Core.Gateway;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Handlers;
using AllAboutGames.Services;

namespace AllAboutGames.Core
{
    public class DependencyManager
    {
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            // Handlers
            builder.Services.AddTransient<GameHandler>();

            // Services
            builder.Services.AddTransient<BaseService>();
            builder.Services.AddTransient<GameService>();

            // Other
            builder.Services.AddTransient<GatewayProtocol>();

            builder.Services.AddAutoMapper(typeof(GameViewModel));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddSwaggerGen();
        }
    }
}
