using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        public HttpResponse Details()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}
