namespace SIS.Demo.Controllers
{
    using Data;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : BaseController
    {
        private const string Username = "username";

        private const string Password = "password";

        private const string ConfirmPassword = "confirmPassword";

        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse LoginConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData[Username]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData[Password]).FirstOrDefault();

                var userFromDb = context.Users
                    .SingleOrDefault(user => user.Username == username && user.Password == password);

                if (userFromDb == null)
                {
                    return this.Redirect("/login");
                }

                httpRequest.Session.AddParameter(Username, userFromDb.Username);
            }

            return this.Redirect("/home");
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse RegisterConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData[Username]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData[Password]).FirstOrDefault();
                var confirmPassword = ((ISet<string>)httpRequest.FormData[ConfirmPassword]).FirstOrDefault();

                if (password != confirmPassword)
                {
                    return this.Redirect("/register");
                }

                var user = new User
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.Redirect("/login");
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();

            return this.Redirect("/");
        }
    }
}
