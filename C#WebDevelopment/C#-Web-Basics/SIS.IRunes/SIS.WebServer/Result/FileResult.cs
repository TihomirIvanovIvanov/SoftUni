namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using HTTP.Headers;

    public class FileResult : ActionResult
    {
        public FileResult(byte[] fileContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok)
            : base(httpResponseStatusCode)
        {                                                         // TODO: constant in GlobalConstant -> Mime type
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentLength, fileContent.Length.ToString()));
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentDisposition, "attacment"));
            this.Content = fileContent;
        }
    }
}
