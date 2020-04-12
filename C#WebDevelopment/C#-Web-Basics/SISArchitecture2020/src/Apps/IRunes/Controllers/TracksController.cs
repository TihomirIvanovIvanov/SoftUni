using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        public HttpResponse Create()
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
