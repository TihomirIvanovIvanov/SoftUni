using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Web.ViewModels.Problems;

namespace SULS.Web.Controllers
{
    public class ProblemsController : Controller
    {
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/users/login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/users/login");
            }

            return this.Redirect("/");
        }
    }
}
