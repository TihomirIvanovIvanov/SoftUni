using Microsoft.EntityFrameworkCore;
using Suls.Models;

namespace Suls.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SulsDb;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
