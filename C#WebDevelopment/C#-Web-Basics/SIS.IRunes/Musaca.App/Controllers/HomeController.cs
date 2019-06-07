namespace Musaca.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        public ActionResult IndexSlash()
        {
            return this.View();
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
