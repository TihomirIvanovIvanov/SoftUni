namespace Musaca.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MusacaDbContext : DbContext
    {
        public MusacaDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(order => order.Product)
                    .WithMany(products => products.Orders);

                entity.HasOne(order => order.Cashier)
                    .WithMany(users => users.Orders);

                entity.HasOne(order => order.Receipt)
                    .WithMany(receipts => receipts.Orders);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasOne(e => e.Cashier)
                    .WithMany(u => u.Receipts);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
