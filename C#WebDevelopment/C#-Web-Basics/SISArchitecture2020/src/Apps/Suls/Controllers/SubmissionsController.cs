using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Data;
using Suls.Services;
using System.Linq;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ApplicationDbContext dbContext, ISubmissionsService submissionsService)
        {
            this.dbContext = dbContext;
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

            var submission = this.dbContext.Submissions.FirstOrDefault(s => s.Id == id);
            this.dbContext.Remove(submission);
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}
