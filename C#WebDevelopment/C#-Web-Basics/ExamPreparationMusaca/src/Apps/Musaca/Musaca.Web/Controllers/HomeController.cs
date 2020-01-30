using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlah()
        {
            return this.Index();
        }
    }
}
