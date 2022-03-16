using Newtonsoft.Json;
#nullable disable

namespace AllAboutGames.Core.Gateway
{
    public class GatewayResult
    {
        public string JsonValue { get; set; }

        public List<GatewayResultDetail> Details { get; set; }

        public static GatewayResult SuccessfullResult()
        {
            return new GatewayResult();
        }

        public void AddError(string message, string property = "")
        {
            this.Details.Add(new GatewayResultDetail(ErrorType.Error, property, message));
        }

        public static GatewayResult FromErrorMessage(string error)
        {
            var result = new GatewayResult();
            result.AddError(error);
            return result;
        }

        public static GatewayResult SuccessfulResult<T>(T obj)
        {
            if (typeof(T) == typeof(GatewayResult))
            {
                return obj as GatewayResult;
            }

            return new GatewayResult
            {
                JsonValue = JsonConvert.SerializeObject(obj)
            };
        }
    }

    public class GatewayResultDetail
    {
        public GatewayResultDetail(ErrorType type, string propertyName, string message)
        {
            this.Type = type;
            this.PropertyName = propertyName;
            this.Message = message;
        }

        public ErrorType Type { get; set; }

        public string PropertyName { get; set; }

        public string Message { get; set; }
    }
}
