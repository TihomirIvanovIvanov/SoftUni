using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using SulsApp.ViewModels.Problems;
using System;
using System.Linq;

namespace SulsApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext db;

        public ProblemsController(IProblemsService problemsService, ApplicationDbContext db)
        {
            this.problemsService = problemsService;
            this.db = db;
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
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name))
            {
                return this.Error("Invalid name");
            }

            if (points <= 0 || points > 100)
            {
                return this.Error("Points range: [1-100]");
            }

            this.problemsService.CreateProblem(name, points);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.db.Problems.Where(p => p.Id == id)
                .Select(p => new DetailsViewModels
                {
                    Name = p.Name,
                    Problems = p.Submissions.Select(s => new ProblemDetailsSubmissionViewModel
                    {
                       SubmissionId = s.Id,
                       CreatedOn = s.CreatedOn,
                       Username = s.User.Username,
                       AchievedResult = s.AchievedResult,
                       MaxPoints = p.Points
                    })
                }).FirstOrDefault();

            return this.View(viewModel);
        }
    }
}
