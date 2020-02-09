using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Home;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var viewModel = this.problemsService.GetAllProblems()
                    .Select(p => new IndexLoggedInViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Count = p.Submissions.Count
                    }).ToList();

                return this.View(viewModel, "IndexLoggedIn");
            }
            return this.View();
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }
    }
}