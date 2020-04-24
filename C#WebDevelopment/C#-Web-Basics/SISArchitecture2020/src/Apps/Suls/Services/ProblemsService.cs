using Suls.Data;
using Suls.Models;
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
    }
}
