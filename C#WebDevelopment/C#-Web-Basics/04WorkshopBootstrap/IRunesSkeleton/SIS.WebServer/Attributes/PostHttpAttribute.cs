using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    public class PostHttpAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Put;
    }
}
