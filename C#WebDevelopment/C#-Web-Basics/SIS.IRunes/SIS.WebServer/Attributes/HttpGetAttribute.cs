namespace SIS.MvcFramework.Attributes
{
    using HTTP.Enums;

    public class HttpGetAttribute : BaseHttpAttribute
    {
        public override HttpRequestMethod Method => HttpRequestMethod.Get;
    }
}
