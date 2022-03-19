using AllAboutGames.Core.Middlewares.Gateway;
using Newtonsoft.Json;
using Serilog;
#nullable disable

namespace AllAboutGames.Core.Gateway
{
    public class GatewayProtocolMiddleware : IMiddleware
    {
        private readonly GatewayProtocol GatewayProtocol;

        public GatewayProtocolMiddleware(GatewayProtocol gatewayProtocol)
        {
            this.GatewayProtocol = gatewayProtocol;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path != "/api/gateway")
            {
                await next(context);
                return;
            }

            string requestBody;
            try
            {
                using (var streamReader = new StreamReader(context.Request.Body, System.Text.Encoding.UTF8))
                {
                    requestBody = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occured while reading the body of the request.", ex);
            }

            GatewayMessage requestMessage;
            try
            {
                requestMessage = JsonConvert.DeserializeObject<GatewayMessage>(requestBody);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to parse JSON request body.", ex);
            }

            // TODO: Get the real IP from the context headers
            Log.Information($"Incoming request: {requestMessage.MessageType} {Environment.NewLine} JSON: {Environment.NewLine} {requestMessage.MessageJson}");

            await this.GatewayProtocol.ProcessGatewayMessage(requestMessage);
        }
    }
}
