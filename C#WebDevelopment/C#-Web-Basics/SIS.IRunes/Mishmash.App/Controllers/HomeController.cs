namespace Mishmash.App.Controllers
{
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        [HttpGet(Url = GlobalConstants.HomeRedirectPath)]
        public ActionResult IndexSlash()
        {
            return Index();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Test(IEnumerable<string> list)
        {
            return this.View();
        }
    }
}
