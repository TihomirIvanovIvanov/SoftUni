using Suls.Data;
using Suls.Models;
using Suls.ViewModels.Problems;
using System.Linq;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext dbContext;

        public ProblemsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.dbContext.Problems.Add(problem);
            this.dbContext.SaveChanges();
        }

        public Problem GetById(string id)
        {
            var problem = this.dbContext.Problems
                .FirstOrDefault(problem => problem.Id == id);

            return problem;
        }

        public DetailsViewModel GetDetailsById(string problemId, string userId)
        {
            var user = this.dbContext.Users.FirstOrDefault(user => user.Id == userId);

            var problemDetailsView = this.dbContext.Problems
                .Where(problem => problem.Id == problemId)
                .Select(problem => new DetailsViewModel
                {
                    Name = problem.Name,
                    Submissions = problem.Submissions.Select(submission => new ProblemSubmissionsDetailsViewModel
                    {
                        SubmissionId = submission.Id,
                        AchievedResult = submission.AchievedResult,
                        MaxPoints = problem.Points,
                        CreatedOn = submission.CreatedOn,
                        Username = user.Username,
                    })
                }).FirstOrDefault();

            return problemDetailsView;
        }
    }
}
