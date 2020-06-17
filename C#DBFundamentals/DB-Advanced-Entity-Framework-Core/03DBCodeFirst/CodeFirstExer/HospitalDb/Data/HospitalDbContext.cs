using HospitalDb.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalDb.Data
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .IsUnicode(true);

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .IsUnicode(true);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .IsUnicode(true);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Visitation>()
                .Property(p => p.Comments)
                .IsUnicode(true);

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Diagnose>()
                .Property(p => p.Comments)
                .IsUnicode(true);

            modelBuilder.Entity<Medicament>()
                .Property(p => p.Name)
                .IsUnicode(true);

            modelBuilder.Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
