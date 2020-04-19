using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Data;
using Suls.Services;
using Suls.ViewModels.Home;
using System.Linq;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = this.dbContext.Problems
                    .Select(problem => new IndexViewModel
                    {
                        Id = problem.Id,
                        Name = problem.Name,
                        Count = problem.Submissions.Count,
                    }).ToList();

                var problemsViewModel = new IndexProblemViewModel { Problems = viewModel };

                return this.View(problemsViewModel, "IndexLoggedIn");
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