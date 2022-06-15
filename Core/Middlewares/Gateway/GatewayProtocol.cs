using AllAboutGames.Core.Handlers;
using AllAboutGames.Services;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System.Reflection;
#nullable disable

namespace AllAboutGames.Core.Middlewares.Gateway
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

        public async Task<GatewayResult> ProcessGatewayMessage(GatewayMessage request, HttpContext context)
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

                var token = context.Request.Headers["Authorization"].FirstOrDefault();
                if (token != null)
                {
                    var jwt = token.Split(' ')[1];
                    var userID = AuthService.DecodeJwtTokent(jwt);
                }

                //var authResult = this.AuthorizeUser(handler, request, session);
                //if (authResult.IsFailed)
                //{
                //    return authResult;
                //}

                var handlerInstance = this.ServiceProvider.GetService(handler.Method.DeclaringType);

                var requestModel = JsonConvert.DeserializeObject(request.MessageJson, handler.RequestType);
                var check = this.ValidateRequestModel(requestModel);
                if (check.IsFailed)
                {
                    return GatewayResult.FromErrorMessage(check.GetErrors());
                }

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

                    throw new NotSupportedException($"Parameters don't match for handler method {handler.Method.DeclaringType.Name}.{handler.Method.Name}");
                })
                .ToArray();

                return await ExecuteHandlerMethod(handler.Method, handlerInstance, parameters);
            }
            catch (Exception ex)
            {
                var message = "Error while trying to process the request: " + request.MessageType;
                Log.Error(ex, message);

                if (Log.IsEnabled(LogEventLevel.Debug))
                {
                    return GatewayResult.FromErrorMessage(ex.Message + Environment.NewLine + ex.InnerException);
                }
                else
                {
                    return GatewayResult.FromErrorMessage(message);
                }
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

                    return GatewayResult.SuccessfulResult();
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

                    return GatewayResult.SuccessfulResult();
                }

                var returnValue = methodInfo.Invoke(handlerInstance, parameters);

                if (returnValue is GatewayResult result)
                {
                    return result;
                }



                return GatewayResult.SuccessfulResult(returnValue);
            }
        }

        private CheckResult ValidateRequestModel(object requestModel)
        {
            var check = new CheckResult();

            // First we validate the main class that is passed to the gateway
            var requestModelValidation = PropertyValidator.Validate(requestModel);
            if (requestModelValidation.IsFailed)
            {
                check.AddError(requestModelValidation.GetErrors());
            }

            // Then we start validating every nested class to see if there are validation errors
            var nestedClasses = requestModel.GetType().GetProperties().Where(x => x.PropertyType.IsClass).ToList();
            foreach (var nestedClass in nestedClasses)
            {
                var currentClass = nestedClass.GetValue(requestModel, null);
                var classValidations = PropertyValidator.Validate(currentClass);
                if (classValidations.IsFailed)
                {
                    check.AddError(classValidations.GetErrors());
                }
            }

            return check;
        }
    }
}
