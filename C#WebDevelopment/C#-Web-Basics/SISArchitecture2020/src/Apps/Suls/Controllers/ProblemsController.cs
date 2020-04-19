using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Data;
using Suls.Services;
using Suls.ViewModels.Problems;
using System.Linq;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext dbContext;

        public ProblemsController(IProblemsService problemsService, ApplicationDbContext dbContext)
        {
            this.problemsService = problemsService;
            this.dbContext = dbContext;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Create();
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Create();
            }

            this.problemsService.Create(input.Name, input.Points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.dbContext.Problems.Where(p => p.Id == id)
                .Select(problem => new DetailsViewModel
            {
                Name = problem.Name,
                Submissions = problem.Submissions.Select(submission => new ProblemSubmissionsDetailsViewModel
                {
                    SubmissionId = submission.Id,
                    AchievedResult = submission.AchievedResult,
                    CreatedOn = submission.CreatedOn,
                    MaxPoints = problem.Points,
                    Username = this.User,
                })
            }).FirstOrDefault();

            return this.View(viewModel);
        }
    }
}
