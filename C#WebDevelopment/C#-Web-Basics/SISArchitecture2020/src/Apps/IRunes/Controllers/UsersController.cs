﻿using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
