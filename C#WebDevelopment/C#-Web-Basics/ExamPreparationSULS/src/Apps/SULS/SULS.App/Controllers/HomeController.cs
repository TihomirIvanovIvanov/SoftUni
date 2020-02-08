using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.View("IndexLoggedIn");
            }
            return this.View();
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }
    }
}