using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Data;
using Suls.Models;
using Suls.ViewModels.Submissions;
using System;
using System.Linq;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Random random;

        public SubmissionsController(ApplicationDbContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.dbContext.Problems
                .Where(p => p.Id == id)
                .Select(problem => new CreateViewModel
                {
                    ProblemId = problem.Id,
                    Name = problem.Name,
                }).FirstOrDefault();


            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code.Length < 30 || code.Length > 800)
            {
                return this.Create(problemId);
            }

            var problem = this.dbContext.Problems.FirstOrDefault(p => p.Id == problemId);
            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                AchievedResult = random.Next(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                UserId = this.User,
            };

            this.dbContext.Submissions.Add(submission);
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var submission = this.dbContext.Submissions.FirstOrDefault(s => s.Id == id);
            this.dbContext.Remove(submission);
            this.dbContext.SaveChanges();

            return this.Redirect("/");
        }
    }
}
