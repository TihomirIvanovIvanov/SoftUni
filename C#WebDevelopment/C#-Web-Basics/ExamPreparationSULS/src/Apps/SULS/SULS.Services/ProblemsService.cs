using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext context;

        public ProblemsService(SULSContext context)
        {
            this.context = context;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();
        }

        public IEnumerable<Problem> GetAllProblems()
        {
            var problems = this.context.Problems.Include(p => p.Submissions).ToList();
            return problems;
        }

        public Problem GetProblemById(string id)
        {
            var problem = this.context.Problems
                
                .FirstOrDefault(p => p.Id == id);

            return problem;
        }
    }
}
