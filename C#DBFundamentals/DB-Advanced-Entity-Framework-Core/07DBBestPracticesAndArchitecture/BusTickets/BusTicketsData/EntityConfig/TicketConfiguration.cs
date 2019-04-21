namespace BusTicketsData.EntityConfig
{
    using BT.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            //builder.HasKey(t => t.TicketId); ????

            //builder.HasAlternateKey(t => new  { t.TicketId, t.CustomerId, t.TripId }); ????

            builder.HasIndex(t => new { t.TicketId, t.CustomerId, t.TripId }).IsUnique();

            builder.HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Trip)
                .WithOne(tr => tr.Ticket)
                .HasForeignKey<Ticket>(t => t.TripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
