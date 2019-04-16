using Microsoft.EntityFrameworkCore;

using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Sales;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(pr =>
            {
                pr.Property(p => p.Name).HasMaxLength(50).IsUnicode(true);
                pr.Property(p => p.Description).HasMaxLength(250).HasDefaultValue("No description");
                pr.ToTable("Products");
            });

            builder.Entity<Customer>(c =>
            {
                c.Property(p => p.Name).HasMaxLength(100).IsUnicode(true);
                c.Property(p => p.Email).HasMaxLength(80).IsUnicode(false);
                c.ToTable("Customers");
            });

            builder.Entity<Store>(s =>
            {
                s.Property(p => p.Name).HasMaxLength(80).IsUnicode(true);
                s.ToTable("Stores");
            });

            builder.Entity<Sale>(s =>
            {
                s.Property(sl => sl.Date).HasDefaultValueSql("GETDATE()");
                
                s.ToTable("Sales");
            });

            builder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(pr => pr.Sales)
                .HasForeignKey("FK_Sales_Products")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(pr => pr.Sales)
                .HasForeignKey("FK_Sales_Customers")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sale>()
                .HasOne(s => s.Store)
                .WithMany(pr => pr.Sales)
                .HasForeignKey("FK_Sales_Stores")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
