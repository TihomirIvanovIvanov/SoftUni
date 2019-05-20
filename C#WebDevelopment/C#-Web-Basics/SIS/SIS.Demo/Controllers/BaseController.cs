namespace SIS.Demo.Controllers
{
    using HTTP.Enums;
    using HTTP.Responses.Contracts;
    using System.IO;
    using System.Runtime.CompilerServices;
    using WebServer.Result;

    public abstract class BaseController
    {
        public IHttpResponse View([CallerMemberName] string view = null)
        {
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var viewName = view;

            var viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            return new HtmlResult(viewContent, HttpResponseStatusCode.Ok);
        }
    }
}
