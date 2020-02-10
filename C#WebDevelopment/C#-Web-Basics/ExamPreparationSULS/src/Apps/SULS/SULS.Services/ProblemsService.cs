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

        public IQueryable<Problem> GetAll()
        {
            var problems = this.context.Problems;
            return problems;
        }

        public Problem GetById(string id)
        {
            var problem = this.context.Problems
                .Include(p => p.Submissions)
                .ThenInclude(s => s.User)
                .FirstOrDefault(p => p.Id == id);

            return problem;
        }
    }
}
