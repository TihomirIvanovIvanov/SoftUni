using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsApp.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext db;

        public SubmissionsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problemView = this.db.Problems
                .Where(p => p.Id == id)
                .Select(p => new CreateFormViewModel
                {
                    ProblemId = p.Id,
                    Name = p.Name
                }).FirstOrDefault();

            return this.View(problemView);
        }

        [HttpPost]
        public HttpResponse Create()
        {
            return this.Redirect("/");
        }
    }
}
