namespace IRunes.App.Controllers
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            if (this.IsLoggedIn(httpRequest))
            {
                this.ViewData[GlobalConstants.Username] = httpRequest.Session.GetParameter(GlobalConstants.username);

                return this.View(GlobalConstants.Home);
            }

            return this.View();
        }
    }
}
