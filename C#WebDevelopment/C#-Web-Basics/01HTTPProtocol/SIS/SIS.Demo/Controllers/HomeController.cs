﻿namespace SIS.Demo.Controllers
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest httpRequest)
        {
            this.HttpRequest = httpRequest;
        }

        public IHttpRequest HttpRequest { get; set; }

        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect("/users/login");
            }

            this.ViewData["Username"] = this.HttpRequest.Session.GetParameter("username");
            return this.View();
        }
    }
}
