using Andreys.Models;
using Microsoft.EntityFrameworkCore;

namespace Andreys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=AndreysDb;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
