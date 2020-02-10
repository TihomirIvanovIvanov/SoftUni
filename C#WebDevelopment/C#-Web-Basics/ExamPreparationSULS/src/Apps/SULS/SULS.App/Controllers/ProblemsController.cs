using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
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
            var detailsModel = this.problemsService.GetById(id);

            var model = new ProblemDetailsViewModel
            {
                Id = detailsModel.Id,
                Name = detailsModel.Name,
                MaxPoints = detailsModel.Points,
                Submissions = detailsModel.Submissions.Select(s => new ProblemDetailsSubmissionViewModel
                {
                    SubmissionId = s.Id,
                    AchievedResult = s.AchievedResult,
                    CreatedOn = s.CreatedOn,
                    Username = s.User.Username
                }).ToList()
            };

            return this.View(model);
        }
    }
}
