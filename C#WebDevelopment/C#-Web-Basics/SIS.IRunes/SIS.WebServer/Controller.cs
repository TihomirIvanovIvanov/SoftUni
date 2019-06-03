namespace SIS.MvcFramework
{
    using Extensions;
    using HTTP.Common;
    using HTTP.Requests;
    using Identity;
    using Result;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using ViewEngine;

    public abstract class Controller
    {
        private IViewEngine viewEngine = new SisViewEngine();

        protected Controller()
        {
            this.ViewData = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> ViewData;

        public Principal User =>
            this.Request.Session.ContainsParameter(GlobalConstants.principal)
            ? (Principal)this.Request.Session.GetParameter(GlobalConstants.principal)
            : null;

        public IHttpRequest Request { get; set; }

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        protected bool IsLoggedIn()
        {
            return this.Request.Session.ContainsParameter(GlobalConstants.principal);
        }

        protected void SignIn(string id, string username, string email)
        {
            this.Request.Session.AddParameter(GlobalConstants.principal, new Principal
            {
                Id = id,
                Username = username,
                Email = email,
            });
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }

        protected ActionResult View([CallerMemberName] string view = null)
        {
            return this.View<object>(null, view);
        }

        protected ActionResult View<T>(T model = null, [CallerMemberName] string view = null)
            where T : class
        {
            // TODO: Support for layout
            var controllerName = this.GetType().Name.Replace(GlobalConstants.Controller, string.Empty);
            var viewName = view;

            var viewContent = System.IO.File.ReadAllText(GlobalConstants.Views + controllerName + "/" + viewName + GlobalConstants.HtmlSuffix);
            viewContent = this.viewEngine.GetHtml(viewContent, model);

            var layoutContent = System.IO.File.ReadAllText("Views/_Layout.html");
            layoutContent = this.viewEngine.GetHtml(layoutContent, model);
            layoutContent = layoutContent.Replace("@RenderBody()", viewContent);

            var htmlResult = new HtmlResult(layoutContent);

            return htmlResult;
        }

        protected ActionResult Redirect(string url)
        {
            return new RedirectResult(url);
        }

        protected ActionResult Xml(object obj)
        {
            return new XmlResult(obj.ToXml());
        }

        protected ActionResult Json(object obj)
        {
            return new JsonResult(obj.ToJson());
        }

        protected ActionResult File(byte[] fileContent)
        {
            return new FileResult(fileContent);
        }

        protected ActionResult NotFound(string message = "")
        {
            return new NotFoundResult(message);
        }
    }
}
