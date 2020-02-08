using Microsoft.EntityFrameworkCore;
using SULS.Models;

namespace SULS.Data
{
    public class SULSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=.;Database=SulsDbExamPart1;Trusted_Connection=True;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submission>()
                .HasOne(submission => submission.Problem);

            modelBuilder.Entity<Submission>()
                .HasOne(submission => submission.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}