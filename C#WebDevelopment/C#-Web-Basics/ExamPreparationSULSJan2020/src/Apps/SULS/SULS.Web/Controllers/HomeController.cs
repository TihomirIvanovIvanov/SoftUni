using SIS.HTTP;
using SIS.MvcFramework;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View("IndexLoggedIn");
            }
            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}