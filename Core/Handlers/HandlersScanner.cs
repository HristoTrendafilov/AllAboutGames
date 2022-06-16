using AllAboutGames.Core.Attributes;
using AllAboutGames.Core.Middlewares;
using AllAboutGames.Core.Middlewares.Gateway;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Core.Handlers
{
    public class HandlersScanner
    {
        public static HandlerCollection ScanForHandlers(params Assembly[] assemblies)
        {
            var methods = assemblies.SelectMany(assembly => assembly.GetTypes())
                                    .SelectMany(type =>
                                                    type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static |
                                                                    BindingFlags.NonPublic))
                                    .Where(info => info.GetCustomAttribute<BindRequestAttribute>() != null);

            var handlerMap = new Dictionary<Type, MethodInfo>();

            var handlers = new List<HandlerCollection.GatewayHandlerModel>();

            foreach (var methodInfo in methods)
            {
                var requestType = methodInfo.GetCustomAttribute<BindRequestAttribute>().RequestType;

                if (!methodInfo.IsPublic)
                {
                    throw new NotSupportedException(string.Format("Handler binding error. The method {0} {1}.{2} is not Public.",
                            requestType.Name,
                            methodInfo.DeclaringType.Name,
                            methodInfo.Name));
                }

                Type[] allowedParameterTypes =
                {
                    typeof(GatewayMessage),
                    typeof(AuthResult),
                };

                foreach (var parameterInfo in methodInfo.GetParameters())
                {
                    if (parameterInfo.ParameterType != requestType && !allowedParameterTypes.Contains(parameterInfo.ParameterType))
                    {
                        throw new NotSupportedException(
                            $"Parameters don't match for handler method {methodInfo.DeclaringType.Name}.{methodInfo.Name}");
                    }
                }

                if (handlerMap.ContainsKey(requestType))
                {
                    var existingMethodInfo = handlerMap[requestType];

                    throw new NotSupportedException(
                        "Handler binding conflict. 2 request types are bound to the same handler method." +
                        string.Format("{0} => {1}.{2}", requestType.Name, existingMethodInfo.DeclaringType.Name, existingMethodInfo.Name) +
                        string.Format("{0} => {1}.{2}", requestType.Name, methodInfo.DeclaringType.Name, methodInfo.Name));
                }

                var returnType = methodInfo.ReturnType;

                if (typeof(Task).IsAssignableFrom(returnType))
                {
                    if (returnType != typeof(Task) && returnType.GetGenericTypeDefinition() != typeof(Task<>))
                    {
                        throw new NotSupportedException("Invalid method return type. If the method is async only Task and Task<T> return types allowed.");
                    }
                }

                handlerMap.Add(requestType, methodInfo);
                handlers.Add(new HandlerCollection.GatewayHandlerModel
                {
                    RequestType = requestType,
                    Method = methodInfo,
                    HandlerType = methodInfo.DeclaringType,
                });
            }

            return new HandlerCollection(handlers);
        }
    }
}
