namespace SIS.WebServer.Results
{
    using Http.Headers;
    using Http.Responses;
    using System.Net;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpStatusCode.Redirect)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}
