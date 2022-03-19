using AllAboutGames.Core.Handlers;
using Newtonsoft.Json;
using Serilog;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Core.Gateway
{
    public class GatewayProtocol
    {
        private readonly HandlerCollection Handlers;
        private readonly IServiceProvider ServiceProvider;

        public GatewayProtocol(HandlerCollection handlers, IServiceProvider serviceProvider)
        {
            this.Handlers = handlers;
            this.ServiceProvider = serviceProvider;
        }

        public async Task<GatewayResult> ProcessGatewayMessage(GatewayMessage request)
        {
            if (request == null)
            {
                return GatewayResult.FromErrorMessage("The request body is empty.");
            }

            if (string.IsNullOrWhiteSpace(request.MessageType))
            {
                return GatewayResult.FromErrorMessage("The request MessageType is empty.");
            }

            if (string.IsNullOrWhiteSpace(request.MessageJson))
            {
                return GatewayResult.FromErrorMessage("The request MessageJson is empty.");
            }

            try
            {
                var handler = this.Handlers.GetHandler(request.MessageType);

                if (handler == null)
                {
                    return GatewayResult.FromErrorMessage("There is no handler that can process the request: " + request.MessageType);
                }

                //var authResult = this.AuthorizeUser(handler, request, session);
                //if (authResult.IsFailed)
                //{
                //    return authResult;
                //}

                var handlerInstance = this.ServiceProvider.GetService(handler.Method.DeclaringType);

                var requestModel = JsonConvert.DeserializeObject(request.MessageJson, handler.RequestType);

                var parameters = handler.Method.GetParameters().Select(info =>
                {
                    if (info.ParameterType == handler.RequestType)
                    {
                        return requestModel;
                    }

                    if (info.ParameterType == typeof(GatewayMessage))
                    {
                        return request;
                    }

                    //if (info.ParameterType == typeof(AuthResult))
                    //{
                    //    return session.AuthResult;
                    //}

                    //if (info.ParameterType == typeof(RequestSession))
                    //{
                    //    return session;
                    //}

                    throw new NotSupportedException($"Parameters don't match for handler method {handler.Method.DeclaringType.Name}.{handler.Method.Name}");
                }).ToArray();

                return await ExecuteHandlerMethod(handler.Method, handlerInstance, parameters);
            }
            catch (Exception ex)
            {
                var message = "Error while trying to process the request: " + request.MessageType;
                Log.Error(ex, message);
                return GatewayResult.FromErrorMessage(message);
            }
        }

        private static async Task<GatewayResult> ExecuteHandlerMethod(MethodInfo methodInfo, object handlerInstance, object[] parameters)
        {
            var taskType = typeof(Task);

            if (taskType.IsAssignableFrom(methodInfo.ReturnType))
            {
                if (methodInfo.ReturnType == taskType)
                {
                    await (Task)methodInfo.Invoke(handlerInstance, parameters);

                    return GatewayResult.SuccessfullResult();
                }

                var task = (Task)methodInfo.Invoke(handlerInstance, parameters);

                await task;

                object returnValue = task.GetType().GetProperty("Result").GetValue(task);

                if (returnValue is GatewayResult result)
                {
                    return result;
                }

                return GatewayResult.SuccessfulResult(returnValue);
            }
            else
            {
                if (methodInfo.ReturnType == typeof(void))
                {
                    methodInfo.Invoke(handlerInstance, parameters);

                    return GatewayResult.SuccessfullResult();
                }

                var returnValue = methodInfo.Invoke(handlerInstance, parameters);

                if (returnValue is GatewayResult result)
                {
                    return result;
                }

                return GatewayResult.SuccessfulResult(returnValue);
            }
        }
    }
}
