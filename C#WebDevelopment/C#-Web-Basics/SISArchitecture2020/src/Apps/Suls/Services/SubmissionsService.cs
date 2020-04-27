using Suls.Data;
using Suls.Models;
using Suls.ViewModels.Submissions;
using System;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext dbContext;
        private readonly Random random;

        public SubmissionsService(IProblemsService problemsService, ApplicationDbContext dbContext, Random random)
        {
            this.problemsService = problemsService;
            this.dbContext = dbContext;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problem = this.problemsService.GetById(problemId);
            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                AchievedResult = random.Next(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
            };

            this.dbContext.Submissions.Add(submission);
            this.dbContext.SaveChanges();
        }

        public CreateViewModel CreateViewModel(string problemId)
        {
            var problem = this.problemsService.GetById(problemId);
            var submissionView = new CreateViewModel
            {
                ProblemId = problem.Id,
                Name = problem.Name,
            };

            return submissionView;
        }
    }
}
