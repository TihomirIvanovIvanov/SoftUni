using Microsoft.EntityFrameworkCore;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<PatientMedicament> PatientMedicament { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity.Property(d => d.Name).HasMaxLength(100).IsUnicode(true);
                entity.Property(d => d.Specialty).HasMaxLength(100).IsUnicode(true);

                entity.HasMany(d => d.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey("FK_Doctors_Visitations");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity.Property(p => p.FirstName).HasMaxLength(50).IsUnicode(true);
                entity.Property(p => p.LastName).HasMaxLength(50).IsUnicode(true);
                entity.Property(p => p.Address).HasMaxLength(250).IsUnicode(true);
                entity.Property(p => p.Email).HasMaxLength(80).IsUnicode(false);
                entity.Property(p => p.HasInsurance);

                entity.HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey("FK_Patients_Visitations");

                entity.HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey("FK_Patients_Diagnoses");

                entity.HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey("FK_Patients_Prescriptions");
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity.Property(d => d.Name).HasMaxLength(50).IsUnicode(true);
                entity.Property(d => d.Comments).HasMaxLength(250).IsUnicode(true);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity.Property(v => v.Date).HasDefaultValueSql("GETDATE()");
                entity.Property(v => v.Comments).HasMaxLength(250).IsUnicode(true);
            });
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            });
        }
    }
}
