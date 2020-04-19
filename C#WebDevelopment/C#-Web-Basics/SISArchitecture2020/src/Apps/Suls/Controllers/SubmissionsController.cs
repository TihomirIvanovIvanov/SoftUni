using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Services;
using Suls.ViewModels.Submissions;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;

        public SubmissionsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.GetById(id);
            var viewModel = new CreateViewModel
            {
                ProblemId = problem.Id,
                Name = problem.Name,
            };

            return this.View(viewModel);
        }
    }
}
