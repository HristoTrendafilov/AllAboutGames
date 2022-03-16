using System.Reflection;
#nullable disable

namespace AllAboutGames.Core.Handlers
{
    public class HandlerCollection
    {
        public HandlerCollection(List<GatewayHandlerModel> handlers)
        {
            this.Handlers = handlers;
            this.HandlersByMessageType = handlers.ToDictionary(model => model.RequestType.Name, model => model);
        }

        private IReadOnlyCollection<GatewayHandlerModel> Handlers { get; }

        private IDictionary<string, GatewayHandlerModel> HandlersByMessageType { get; set; }

        public List<GatewayHandlerModel> GetAllHandlers()
        {
            return this.Handlers.ToList();
        }

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
