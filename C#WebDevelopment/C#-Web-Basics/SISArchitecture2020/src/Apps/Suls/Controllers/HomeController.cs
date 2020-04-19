﻿using SIS.HTTP;
using SIS.MvcFramework;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}