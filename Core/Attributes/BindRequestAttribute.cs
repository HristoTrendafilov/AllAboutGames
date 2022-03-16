#nullable disable
namespace AllAboutGames.Core.Attributes
{
    public class BindRequestAttribute : Attribute
    {
        public BindRequestAttribute(Type requestType, Type responseType = null)
        {
            this.RequestType = requestType;
            this.ResponseType = responseType;
        }

        public Type RequestType { get; }

        public Type ResponseType { get; set; }
    }
}
