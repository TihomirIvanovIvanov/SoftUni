using Microsoft.EntityFrameworkCore;
using Panda101.Data.Models;

namespace Panda101.Data
{
    public class Panda101DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PandaDbExamPart1;Trusted_Connection=True;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(u => u.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(u => u.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
