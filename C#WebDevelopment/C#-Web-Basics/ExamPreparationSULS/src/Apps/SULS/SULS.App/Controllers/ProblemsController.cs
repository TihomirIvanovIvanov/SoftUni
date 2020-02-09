using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemsService.GetProblemById(id);

            var details = new ProblemDetailsViewModel
            {
                Name = problem.Name,
                MaxPoints = problem.Points,
                Submissions = problem.Submissions.Select(s => new SubmissionViewModel
                {
                    Username = s.User.Username,
                    MaxPoints = s.AchievedResult,
                    CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy"),
                    SubmissionId = s.Id
                })
            };

            return this.View(details);
        }
    }
}
