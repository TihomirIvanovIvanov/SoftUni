namespace SIS.MvcFramework.Result
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using System.Text;

    public class TextResult : ActionResult
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode,
            string contentType = GlobalConstants.TextPlainMimeType)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode,
            string contentType = GlobalConstants.TextPlainMimeType)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = content;
        }
    }
}
