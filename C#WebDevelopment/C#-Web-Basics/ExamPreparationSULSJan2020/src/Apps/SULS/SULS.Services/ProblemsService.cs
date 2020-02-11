using SULS.Data;
using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SUSLContext context;

        public ProblemsService(SUSLContext context)
        {
            this.context = context;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();
        }

        public IQueryable<Problem> GetAll()
        {
            var problems = this.context.Problems.AsQueryable();
            return problems;
        }
    }
}
