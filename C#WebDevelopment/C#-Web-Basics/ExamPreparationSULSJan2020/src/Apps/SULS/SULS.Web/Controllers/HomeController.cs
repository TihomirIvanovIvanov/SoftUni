using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.Web.ViewModels.Home;
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

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var view = this.problemsService.GetAll()
                    .Select(p => new IndexLogInInputModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Count = p.Submissions.Count,
                    }).ToList();

                return this.View(view, "IndexLoggedIn");
            }
            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}