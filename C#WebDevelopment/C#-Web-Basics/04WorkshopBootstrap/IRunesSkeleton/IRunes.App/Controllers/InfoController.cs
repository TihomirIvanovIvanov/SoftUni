using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer;

namespace IRunes.App.Controllers
{
    public class InfoController : Controller
    {
        public int MyProperty { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public IHttpResponse About(IHttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
