using AllAboutGames.Core.Handlers;
using AllAboutGames.Core.Middlewares.Gateway;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using System.Reflection;

namespace AllAboutGames.Core
{
    public class DependencyManager
    {
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            // Handlers
            var handlers = HandlersScanner.ScanForHandlers(Assembly.GetExecutingAssembly());
            foreach (var handler in handlers.GetAllHandlers())
            {
                builder.Services.AddTransient(handler.HandlerType);
            }

            // Services
            builder.Services.AddTransient<BaseService>();
            builder.Services.AddTransient<GameService>();

            // Middlewares
            builder.Services.AddTransient<GatewayProtocolMiddleware>();

            // Other
            builder.Services.AddTransient(provider => new GatewayProtocol(handlers, provider));

            builder.Services.AddAutoMapper(typeof(GameViewModel));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddSwaggerGen();
        }
    }
}
