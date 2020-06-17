using Microsoft.EntityFrameworkCore;
using SalesDb.Models;
using System.Globalization;

namespace SalesDb.Data
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Sale;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
               .Property(p => p.Description)
               .IsRequired()
               .IsUnicode()
               .HasMaxLength(250)
               .HasDefaultValue("No description");

            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(80);

            modelBuilder.Entity<Store>()
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(80);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.CustumerId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Store)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.StoreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
