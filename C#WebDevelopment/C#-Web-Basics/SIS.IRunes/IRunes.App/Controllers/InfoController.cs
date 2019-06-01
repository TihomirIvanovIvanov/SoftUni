namespace IRunes.App.Controllers
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Reflection;

    public class InfoController : Controller
    {
        public int MyProperty { get; set; }

        [NonAction]
        public override string ToString()
        {
            return base.ToString();
        }

        public ActionResult Json(IHttpRequest request)
        {
            return Xml(new Model
            {
                Name = "Pesho",
                Age = 25,
                Occupation = "Bezraboten",
                IsMarried = true
            });
        }

        public ActionResult File(IHttpRequest request)
        {
            var folderPrefix = "/../";
            var assemblyLocation = this.GetType().Assembly.Location;
            var resourceFolderPath = "Resources/";
            var requestedResource = request.QueryData["file"].ToString();

            var fullPathToResource = assemblyLocation + folderPrefix + resourceFolderPath + requestedResource;

            if (System.IO.File.Exists(fullPathToResource))
            {
                string mimeType = null;
                string fileName = null;

                var content = System.IO.File.ReadAllBytes(fullPathToResource);
                return File(content);
            }

            return NotFound();
        }

        public IHttpResponse About(IHttpRequest request)
        {
            return this.View();
        }
    }
}
