namespace SIS.MvcFramework
{
    using HTTP.Common;
    using HTTP.Requests;
    using Identity;
    using Result;
    using SIS.MvcFramework.Extensions;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Controller()
        {
            this.ViewData = new Dictionary<string, object>();
        }

        protected Dictionary<string, object> ViewData;

        protected Principal User => (Principal)this.Request.Session.GetParameter("principal");

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
            return this.User != null;
        }

        protected void SignIn(string id, string username, string email)
        {
            this.Request.Session.AddParameter("principal", new Principal
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
            var controllerName = this.GetType().Name.Replace(GlobalConstants.Controller, string.Empty);
            var viewName = view;

            var viewContent = System.IO.File.ReadAllText(GlobalConstants.Views + controllerName + "/" + viewName + GlobalConstants.HtmlSuffix);

            viewContent = this.ParseTemplate(viewContent);

            var htmlResult = new HtmlResult(viewContent);

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
