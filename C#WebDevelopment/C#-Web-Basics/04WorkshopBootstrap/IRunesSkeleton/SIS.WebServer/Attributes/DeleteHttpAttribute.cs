using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    public class DeleteHttpAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Delete;
    }
}
