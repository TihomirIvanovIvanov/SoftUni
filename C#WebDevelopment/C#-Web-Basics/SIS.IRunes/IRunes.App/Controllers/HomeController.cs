namespace IRunes.App.Controllers
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            if (this.IsLogedIn(httpRequest))
            {
                this.ViewData[GlobalConstants.Username] = httpRequest.Session.GetParameter(GlobalConstants.username);
                return this.View(GlobalConstants.Home);
            }

            return this.View();
        }
    }
}
