namespace SIS.Demo.Data
{
    using Demo.Models;
    using Microsoft.EntityFrameworkCore;

    public class DemoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DemoDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TI6OPACATA;Database=DemoDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
