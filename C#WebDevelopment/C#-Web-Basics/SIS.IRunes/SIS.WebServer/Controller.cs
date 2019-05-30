namespace SIS.MvcFramework
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using WebServer.Result;

    public abstract class Controller
    {
        protected Controller()
        {
            this.ViewData = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> ViewData;

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        protected bool IsLoggedIn(IHttpRequest httpRequest)
        {
            return httpRequest.Session.ContainsParameter(GlobalConstants.username);
        }

        protected void SignIn(IHttpRequest httpRequest, string id, string username, string email)
        {
            httpRequest.Session.AddParameter(GlobalConstants.id, id);
            httpRequest.Session.AddParameter(GlobalConstants.username, username);
            httpRequest.Session.AddParameter(GlobalConstants.email, email);
        }

        protected void SignOut(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();
        }

        protected IHttpResponse View([CallerMemberName] string view = null)
        {
            var controllerName = this.GetType().Name.Replace(GlobalConstants.Controller, string.Empty);
            var viewName = view;

            var viewContent = File.ReadAllText(GlobalConstants.Views + controllerName + "/" + viewName + GlobalConstants.HtmlSuffix);

            viewContent = this.ParseTemplate(viewContent);

            var htmlResult = new HtmlResult(viewContent);

            return htmlResult;
        }

        protected IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}
