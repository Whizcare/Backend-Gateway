using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntities.Entities;

public partial class ProjectDatabaseContext : DbContext
{
    public ProjectDatabaseContext()
    {
    }

    public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Server=tcp:bhargav-db-1.database.windows.net,1433;Initial Catalog=ProjectDatabase;Persist Security Info=False;User ID=bhargav7342;Password=Bhargav@420;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");



    public virtual DbSet<HealthHistory> HealthHistories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HealthHistory>(entity =>
        {
            entity.HasKey(e => e.HhId).HasName("PK__Health_H__CA9AAAF8425977C1");

            entity.ToTable("Health_History");

            entity.Property(e => e.HhId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("HH_Id");
            entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Diagnosis).IsUnicode(false);
            entity.Property(e => e.DoctorName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Doctor_Name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

            entity.HasOne(d => d.Patient).WithMany(p => p.HealthHistories)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Health_History.Patient_Id");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__C1A88B79CA5C673A");

            entity.ToTable("Patient");

            entity.HasIndex(e => e.Email, "UQ__Patient__A9D10534496CBE55").IsUnique();

            entity.Property(e => e.PatientId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Patient_Id");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Blood_group");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_of_Birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__E82EBD38F974DB76");

            entity.Property(e => e.PrescriptionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Prescription_Id");
            entity.Property(e => e.Dosage)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.HhId).HasColumnName("HH_Id");
            entity.Property(e => e.MedicineName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medicine_Name");
            entity.Property(e => e.Note).IsUnicode(false);

            entity.HasOne(d => d.Hh).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.HhId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Prescriptions.HH_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
