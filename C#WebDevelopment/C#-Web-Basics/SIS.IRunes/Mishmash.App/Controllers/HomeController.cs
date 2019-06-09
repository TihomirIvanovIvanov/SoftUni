namespace Mishmash.App.Controllers
{
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;

    public class HomeController : Controller
    {
        [HttpGet(Url = GlobalConstants.HomeRedirectPath)]
        public ActionResult IndexSlash()
        {
            return this.Index();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        //[HttpGet(Url = "/Home/Index")]
        //public ActionResult HomeIndex()
        //{
        //    if (this.User != null)
        //    {
        //        // TODO: prepare view model
        //        return this.View("Home/LoggedInIndex");
        //    }
        //    else
        //    {
        //        return this.View("Home/Index");
        //    }
        //}
    }
}
