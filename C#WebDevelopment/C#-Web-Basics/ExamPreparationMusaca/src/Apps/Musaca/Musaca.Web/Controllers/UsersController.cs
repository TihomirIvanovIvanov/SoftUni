using SIS.MvcFramework;
using SIS.MvcFramework.Result;

namespace Musaca.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }
    }
}
