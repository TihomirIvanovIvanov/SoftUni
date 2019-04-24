namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalAid> AnimalAids { get; set; }

        public DbSet<Passport> Passports { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

        public DbSet<Vet> Vets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.Passport)
                .WithOne(p => p.Animal)
                .HasForeignKey<Passport>(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Passport>(entity => 
            {
                entity.HasKey(p => p.SerialNumber);

                entity.HasOne(p => p.Animal)
                .WithOne(a => a.Passport);

                entity.Property(p => p.AnimalId).IsRequired(false);
            });

            builder.Entity<Vet>().HasIndex(v => v.PhoneNumber).IsUnique();

            builder.Entity<AnimalAid>().HasIndex(a => a.Name).IsUnique();

            builder.Entity<ProcedureAnimalAid>(entity =>
            {
                entity.HasKey(pa => new { pa.ProcedureId, pa.AnimalAidId });

                entity.HasOne(pa => pa.Procedure)
                .WithMany(p => p.ProcedureAnimalAids)
                .HasForeignKey(p => p.ProcedureId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pa => pa.AnimalAid)
                .WithMany(p => p.AnimalAidProcedures)
                .HasForeignKey(p => p.AnimalAidId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
