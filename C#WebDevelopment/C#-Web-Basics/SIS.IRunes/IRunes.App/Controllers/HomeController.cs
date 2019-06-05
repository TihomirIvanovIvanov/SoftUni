namespace IRunes.App.Controllers
{
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        [HttpGet(Url = GlobalConstants.HomeRedirectPath)]
        public ActionResult IndexSlash()
        {
            return Index();
        }

        public ActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.View(new UserHomeViewModel { Username = this.User.Username }, GlobalConstants.Home);
            }

            return this.View();
        }

        public ActionResult Test(IEnumerable<string> list)
        {
            return this.View();
        }
    }
}
