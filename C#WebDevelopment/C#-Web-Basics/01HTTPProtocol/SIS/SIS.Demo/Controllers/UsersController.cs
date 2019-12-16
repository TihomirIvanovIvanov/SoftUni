namespace SIS.Demo.Controllers
{
    using global::Demo.Data;
    using global::Demo.Models;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : BaseController
    {
        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse LoginConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData["username"]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData["password"]).FirstOrDefault();

                var userFromDb = context.Users
                    .SingleOrDefault(user => user.Username == username && user.Password == password);

                if (userFromDb == null)
                {
                    return this.Redirect("/users/login");
                }

                httpRequest.Session.AddParameter("username", userFromDb.Username);
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
                var username = ((ISet<string>)httpRequest.FormData["username"]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData["password"]).FirstOrDefault();
                var confrimPassword = ((ISet<string>)httpRequest.FormData["confirmPassword"]).FirstOrDefault();

                if (password != confrimPassword)
                {
                    return this.Redirect("/users/register");
                }

                var user = new User
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.Redirect("/users/login");
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();

            return this.Redirect("/");
        }
    }
}
