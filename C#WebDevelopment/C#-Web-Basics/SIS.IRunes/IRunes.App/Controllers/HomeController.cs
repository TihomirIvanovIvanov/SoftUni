namespace IRunes.App.Controllers
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
            return Index();
        }

        public ActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                this.ViewData[GlobalConstants.Username] = this.User.Username; ;

                return this.View(GlobalConstants.Home);
            }

            return this.View();
        }
    }
}
