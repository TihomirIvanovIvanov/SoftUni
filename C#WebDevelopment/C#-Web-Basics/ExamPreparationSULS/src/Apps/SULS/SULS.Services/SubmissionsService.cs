using SULS.Data;
using SULS.Models;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext context;
        private readonly IProblemsService problemsService;

        public SubmissionsService(SULSContext context, IProblemsService problemsService)
        {
            this.context = context;
            this.problemsService = problemsService;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problem = problemsService.GetById(problemId);

            var submission = new Submission
            {
                ProblemId = problemId,
                Code = code,
                AchievedResult = RandomNumber(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                UserId = userId
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();
        }

        public void Delete(string id)
        {
            var deletedSub = this.context.Submissions
                .FirstOrDefault(s => s.Id == id);

            this.context.Remove(deletedSub);
            this.context.SaveChanges();
        }

        public IQueryable<Submission> GetAll()
        {
            var submissions = this.context.Submissions;
            return submissions;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
