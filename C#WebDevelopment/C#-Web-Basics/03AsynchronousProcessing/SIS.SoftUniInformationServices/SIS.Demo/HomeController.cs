namespace SIS.Demo
{
    using Http.Responses.Contacts;
    using System.Net;
    using WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
