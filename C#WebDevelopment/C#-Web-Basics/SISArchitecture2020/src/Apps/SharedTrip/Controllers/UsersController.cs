﻿using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
            return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return this.Login();
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Register();
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Register();
            }

            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
                return this.Register();
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Register();
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return this.Register();
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Register();
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Login();
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
