namespace SIS.Demo.Controllers
{
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using WebServer.Result;

    public abstract class BaseController
    {
        private const string Username = "username";

        protected IHttpRequest HttpRequest { get; set; }

        protected Dictionary<string, object> ViewData = new Dictionary<string, object>();

        protected bool IsLoggedIn()
        {
            return this.HttpRequest.Session.ContainsParameter(Username);
        }

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        public IHttpResponse View([CallerMemberName] string view = null)
        {
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var viewName = view;

            var viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            viewContent = this.ParseTemplate(viewContent);

            var htmlResult = new HtmlResult(viewContent, HttpResponseStatusCode.Ok);

            return htmlResult;
        }

        public IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}
