namespace SIS.WebServer.Result
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;

    public class InlineResourceResult : HttpResponse
    {
        public InlineResourceResult(byte[] content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentLength, content.Length.ToString()));
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentDisposition, GlobalConstants.InlineResourceResult));
            this.Content = content;
        }
    }
}
