namespace IRunes.App.Controllers
{
    using Data;
    using Models;
    using SIS.HTTP.Common;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersController : Controller
    {
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View();
        }

        [HttpPost(ActionName = "Login")]
        public IHttpResponse LoginConfirm(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData[GlobalConstants.username]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData[GlobalConstants.password]).FirstOrDefault();

                var userFromDb = context
                    .Users
                    .FirstOrDefault
                    (user => (user.Username == username || user.Email == username) && user.Password == this.HashPassword(password));

                if (userFromDb == null)
                {
                    return this.Redirect(GlobalConstants.UsersLoginPath);
                }

                this.SignIn(httpRequest, userFromDb.Id, userFromDb.Username, userFromDb.Email);
            }

            return this.Redirect(GlobalConstants.HomeRedirectPath);
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View();
        }

        [HttpPost(ActionName = "Register")]
        public IHttpResponse RegisterConfirm(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData[GlobalConstants.username]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData[GlobalConstants.password]).FirstOrDefault();
                var confirmPassword = ((ISet<string>)httpRequest.FormData[GlobalConstants.confirmPassword]).FirstOrDefault();
                var email = ((ISet<string>)httpRequest.FormData[GlobalConstants.email]).FirstOrDefault();

                if (password != confirmPassword)
                {
                    return this.Redirect(GlobalConstants.UsersRegisterPath);
                }

                var user = new User
                {
                    Username = username,
                    Password = this.HashPassword(password),
                    Email = email
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.Redirect(GlobalConstants.UsersLoginPath);
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            this.SignOut(httpRequest);

            return this.Redirect(GlobalConstants.HomeRedirectPath);
        }
    }
}