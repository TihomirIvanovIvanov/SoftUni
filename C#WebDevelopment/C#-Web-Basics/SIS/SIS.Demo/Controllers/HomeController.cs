namespace SIS.Demo.Controllers
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
