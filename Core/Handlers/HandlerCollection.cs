using System.Reflection;
#nullable disable

namespace AllAboutGames.Core.Handlers
{
    public class HandlerCollection
    {
        public HandlerCollection(IReadOnlyCollection<GatewayHandlerModel> handlers)
        {
            this.HandlersByMessageType = handlers.ToDictionary(model => model.RequestType.Name, model => model);
        }

        private IDictionary<string, GatewayHandlerModel> HandlersByMessageType { get; set; }

        public GatewayHandlerModel GetHandler(string messageType)
        {
            if (!this.HandlersByMessageType.ContainsKey(messageType))
            {
                return null;
            }

            return this.HandlersByMessageType[messageType];
        }

        public class GatewayHandlerModel
        {
            public Type HandlerType { get; set; }

            public MethodInfo Method { get; set; }

            public Type RequestType { get; set; }
        }
    }
}
