﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20171111181535_AddDoctor")]
    partial class AddDoctor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Diagnose", b =>
                {
                    b.Property<int>("DiagnoseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<int>("FK_Patients_Diagnoses");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<int>("PatientId");

                    b.HasKey("DiagnoseId");

                    b.HasIndex("FK_Patients_Diagnoses");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Specialty")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("Name");

                    b.Property<int>("PatientId");

                    b.HasKey("MedicamentId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<int>("DiagnoseId");

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<bool>("HasInsurance");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<int>("VisitationId");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.PatientMedicament", b =>
                {
                    b.Property<int>("PatientId");

                    b.Property<int>("MedicamentId");

                    b.Property<int>("FK_Patients_Prescriptions");

                    b.HasKey("PatientId", "MedicamentId");

                    b.HasIndex("FK_Patients_Prescriptions");

                    b.HasIndex("MedicamentId");

                    b.ToTable("PatientMedicament");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Visitation", b =>
                {
                    b.Property<int>("VisitationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DoctorId");

                    b.Property<int>("FK_Doctors_Visitations");

                    b.Property<int>("FK_Patients_Visitations");

                    b.Property<int>("PatientId");

                    b.HasKey("VisitationId");

                    b.HasIndex("FK_Doctors_Visitations");

                    b.HasIndex("FK_Patients_Visitations");

                    b.ToTable("Visitations");
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Diagnose", b =>
                {
                    b.HasOne("P01_HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Diagnoses")
                        .HasForeignKey("FK_Patients_Diagnoses")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.PatientMedicament", b =>
                {
                    b.HasOne("P01_HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("FK_Patients_Prescriptions")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("P01_HospitalDatabase.Data.Models.Medicament", "Medicament")
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("P01_HospitalDatabase.Data.Models.Visitation", b =>
                {
                    b.HasOne("P01_HospitalDatabase.Data.Models.Doctor", "Doctor")
                        .WithMany("Visitations")
                        .HasForeignKey("FK_Doctors_Visitations")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("P01_HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Visitations")
                        .HasForeignKey("FK_Patients_Visitations")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
