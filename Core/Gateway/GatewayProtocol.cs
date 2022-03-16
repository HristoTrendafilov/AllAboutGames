using AllAboutGames.Core.Handlers;
using Newtonsoft.Json;

namespace AllAboutGames.Core.Gateway
{
    public class GatewayProtocol
    {
        private readonly HandlerCollection Handlers;

        public GatewayProtocol(HandlerCollection handlers)
        {
            this.Handlers = handlers;
        }

        public async Task<GatewayResult> ProcessGatewayMessage(GatewayMessage request, RequestSession session)
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
                    return GatewayResult.FromErrorMessage("Няма Handler, който да обработи заявка с тип " + request.MessageType);
                }

                var authResult = this.AuthorizeUser(handler, request, session);
                if (authResult.IsFailed)
                {
                    return authResult;
                }

                var handlerInstance = this.serviceProvider.Resolve(handler.Method.DeclaringType);

                var requestModel = JsonConvert.DeserializeObject(request.MessageJson, handler.RequestType, SerializerSettings);

                var (isValid, validationErrorMessages) = DataValidator.Validate(requestModel);

                if (!isValid)
                {
                    return GatewayResult.FromErrorMessage(validationErrorMessages);
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

                    if (info.ParameterType == typeof(AuthResult))
                    {
                        return session.AuthResult;
                    }

                    if (info.ParameterType == typeof(RequestSession))
                    {
                        return session;
                    }

                    throw new NotSupportedException($"Parameters don't match for handler method {handler.Method.DeclaringType.Name}.{handler.Method.Name}");
                }).ToArray();

                try
                {
                    if (!handler.ExecuteInTransaction)
                    {
                        return await ExecuteHandlerMethod(handler.Method, handlerInstance, parameters);
                    }

                    var db = this.serviceProvider.Resolve<ISqlVisitor>();

                    try
                    {
                        db.BeginTransaction();

                        var result = await ExecuteHandlerMethod(handler.Method, handlerInstance, parameters);

                        if (!result.Success)
                        {
                            db.RollbackTransaction();
                            return result;
                        }

                        db.TryCommit();

                        return result;
                    }
                    catch (Exception)
                    {
                        db.RollbackTransaction();
                        throw;
                    }
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                        throw new NotImplementedException();
                    }

                    throw;
                }
            }
            catch (Exception ex)
            {
                MainLogger.Error(ex);

                if (ex is GatewayResult.FailedJCoreRequestException failedException)
                {
                    return failedException.GatewayResult;
                }

                string message;

#pragma warning disable 162
                if (Global.AppConfig.Debug.DetailedGatewayErrors)
                {
                    message = ex.ToString();
                }
                else
                {
                    message = "Грешка при обработката на заявка от тип " + request.MessageType;
                }
#pragma warning restore 162

                return GatewayResult.FromErrorMessage(message);
            }
        }
    }
}
