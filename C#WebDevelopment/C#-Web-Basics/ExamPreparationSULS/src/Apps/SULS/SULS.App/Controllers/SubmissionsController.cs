using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Submissions;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        private readonly IProblemsService problemsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemsService.GetById(id);

            var submissionModel = new CreateViewModel
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(submissionModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateSubmissionViewModel input)
        {
            var userId = this.User.Id;

            this.submissionsService.Create(input.ProblemId, userId, input.Code);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
