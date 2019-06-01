namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using HTTP.Headers;
    using System.Text;

    public class XmlResult : ActionResult
    {
        public XmlResult(string xmlContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok)
            : base(httpResponseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "application/xml"));
            this.Content = Encoding.UTF32.GetBytes(xmlContent);
        }
    }
}
