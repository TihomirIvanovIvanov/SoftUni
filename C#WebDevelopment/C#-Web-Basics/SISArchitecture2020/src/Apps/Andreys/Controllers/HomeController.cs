using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
