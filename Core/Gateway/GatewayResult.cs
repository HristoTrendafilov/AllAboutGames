namespace AllAboutGames.Core.Gateway
{
    public class GatewayResult
    {
        public string JsonValue { get; set; }

        public static void SuccessfullResult<T>(T @object)
        {

        }
    }
}
