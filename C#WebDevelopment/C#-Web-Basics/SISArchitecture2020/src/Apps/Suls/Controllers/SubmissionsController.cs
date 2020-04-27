using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Services;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.submissionsService.CreateViewModel(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code.Length < 30 || code.Length > 800)
            {
                return this.Create(problemId);
            }

            this.submissionsService.Create(problemId, this.User, code);
            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.DeleteById(id);
            return this.Redirect("/");
        }
    }
}
