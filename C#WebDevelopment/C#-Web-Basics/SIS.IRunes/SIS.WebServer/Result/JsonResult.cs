namespace SIS.MvcFramework.Result
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Headers;
    using System.Text;

    public class JsonResult : ActionResult
    {
        public JsonResult(string jsonContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok)
            : base(httpResponseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, GlobalConstants.ApplicationJsonResourceResult));
            this.Content = Encoding.UTF32.GetBytes(jsonContent);
        }
    }
}
