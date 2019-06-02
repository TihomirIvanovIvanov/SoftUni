namespace SIS.MvcFramework.Result
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using System.Text;

    public class HtmlResult : ActionResult
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode = HttpResponseStatusCode.Ok)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, GlobalConstants.TextHtmlResourceResult));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
