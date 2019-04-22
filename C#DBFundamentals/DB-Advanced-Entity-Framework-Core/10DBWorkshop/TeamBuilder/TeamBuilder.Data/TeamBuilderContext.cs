using Microsoft.EntityFrameworkCore;
using TeamBuilder.Models;

namespace TeamBuilder.Data
{
    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
        {
        }

        public TeamBuilderContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<UserTeam> UserTeams { get; set; }

        public DbSet<EventTeam> EventTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=TeamBuilder;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.HasMany(u => u.Events)
                .WithOne(e => e.User)
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Invitations)
                .WithOne(i => i.User)
                .HasForeignKey(u => u.InvitedUserId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Teams)
                .WithOne(t => t.User)
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.EventTeams)
                .WithOne(et => et.Event)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.HasMany(t => t.UserTeams)
                .WithOne(ut => ut.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.EventTeams)
                .WithOne(et => et.Team)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.Invitations)
                .WithOne(i => i.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Invitation>(entity =>
            {
                entity.HasKey(i => i.Id);
            });

            builder.Entity<UserTeam>(entity =>
            {
                entity.HasKey(ut => new { ut.UserId, ut.TeamId });
            });

            builder.Entity<EventTeam>(entity =>
            {
                entity.HasKey(et => new { et.EventId, et.TeamId });
            });
        }
    }
}