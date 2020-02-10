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
                var indexModel = this.problemsService.GetAll()
                    .Select(p => new IndexLoggedInViewModel
                    {
                        Id = p.Id,
                        Count = p.Submissions.Count,
                        Name = p.Name
                    })
                    .ToList();

                return this.View(indexModel  ,"IndexLoggedIn");
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