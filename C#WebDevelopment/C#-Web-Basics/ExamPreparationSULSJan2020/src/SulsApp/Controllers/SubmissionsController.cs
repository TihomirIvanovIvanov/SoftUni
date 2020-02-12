using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Models;
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
        private readonly Random random;

        public SubmissionsController(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
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
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please provide code with at least 30 characters!");
            }

            var problem = this.db.Problems.FirstOrDefault(p => p.Id == problemId);

            var submission = new Submission
            {
                CreatedOn = DateTime.UtcNow,
                UserId = this.User,
                ProblemId = problemId,
                Code = code,
                AchievedResult = this.random.Next(0, problem.Points)
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var submission = this.db.Submissions.FirstOrDefault(s => s.Id == id);
            this.db.Remove(submission);
            this.db.SaveChanges();

            return this.Redirect("/");
        }
    }
}
