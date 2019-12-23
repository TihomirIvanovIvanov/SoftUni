using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    public class GetHttpAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Get;
    }
}
