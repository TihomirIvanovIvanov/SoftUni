using Suls.Data;
using Suls.Models;
using System.Collections.Generic;
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

        public IEnumerable<Problem> GetAll()
        {
            var problems = this.dbContext.Problems.ToList();
            return problems;
        }
    }
}
