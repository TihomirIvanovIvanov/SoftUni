namespace SIS.MvcFramework.Result
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using System.Text;

    public class XmlResult : ActionResult
    {
        public XmlResult(string xmlContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok)
            : base(httpResponseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, GlobalConstants.ApplicationXmlResourceResult));
            this.Content = Encoding.UTF32.GetBytes(xmlContent);
        }
    }
}
