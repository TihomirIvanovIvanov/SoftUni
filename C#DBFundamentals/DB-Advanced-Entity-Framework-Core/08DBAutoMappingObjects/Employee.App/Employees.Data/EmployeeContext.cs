namespace Employees.Data
{
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.Address)
                .HasMaxLength(250);
            });
        }
    }
}
