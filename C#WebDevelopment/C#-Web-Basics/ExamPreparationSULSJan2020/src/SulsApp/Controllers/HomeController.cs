using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.ViewModels.Home;
using System.Linq;

namespace SulsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var problem = db.Problems.Select(p => new IndexProblemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count(),
                }).ToList();

                var view = new LoggedInViewModel
                {
                    Problems = problem,
                };

                return this.View(view, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
