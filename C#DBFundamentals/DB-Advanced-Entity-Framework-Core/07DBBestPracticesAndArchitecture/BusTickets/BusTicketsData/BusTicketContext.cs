namespace BusTicketsData
{
    using Microsoft.EntityFrameworkCore;

    using BT.Data.Models;
    using BusTicketsData.EntityConfig;
   

    public class BusTicketContext : DbContext
    {
        public BusTicketContext()
        {
        }

        public BusTicketContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<BusCompany> BusCompanies { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<BusStation> BusStations { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Review> Rewiews { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusCompanyConfiguration());

            modelBuilder.ApplyConfiguration(new BankAccountCongiguration());

            modelBuilder.ApplyConfiguration(new BusStationConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new ReviewConfiguration());

            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.ApplyConfiguration(new TownConfiguration());

            modelBuilder.ApplyConfiguration(new TripConfiguration());
        }
    }
}
