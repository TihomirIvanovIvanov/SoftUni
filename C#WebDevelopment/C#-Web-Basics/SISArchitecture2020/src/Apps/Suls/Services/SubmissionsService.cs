using Suls.Data;
using Suls.ViewModels.Submissions;
using System.Linq;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext dbContext;

        public SubmissionsService(IProblemsService problemsService, ApplicationDbContext dbContext)
        {
            this.problemsService = problemsService;
            this.dbContext = dbContext;
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
