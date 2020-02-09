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

        public IEnumerable<Problem> GetAllProblems()
        {
            var problems = this.context.Problems.Include(p => p.Submissions).ToList();
            return problems;
        }
    }
}
