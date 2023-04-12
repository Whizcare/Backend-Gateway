using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntities.Entities;

public partial class DoctorDbContext : DbContext
{
    public DoctorDbContext()
    {
    }

    public DoctorDbContext(DbContextOptions<DoctorDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Server=tcp:cibi-server.database.windows.net,1433;Initial Catalog=DoctorDB;Persist Security Info=False;User ID=cibi619;Password=Cibi@619;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<PhysicianAvailabilityStatus> PhysicianAvailabilityStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__DOCTORS__E59B532FB76DD8C1");

            entity.ToTable("DOCTORS");

            entity.HasIndex(e => e.Email, "Email_Unique").IsUnique();

            entity.Property(e => e.DoctorId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Doctor_Id");
            entity.Property(e => e.Department)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DoctorName)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Doctor_Name");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qualification)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PhysicianAvailabilityStatus>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__Physicia__9F33919BD280FE79");

            entity.ToTable("Physician_Availability_Status");

            entity.Property(e => e.AvailabilityId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Availability_Id");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

            entity.HasOne(d => d.Doctor).WithMany(p => p.PhysicianAvailabilityStatuses)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Physician__Docto__4D5F7D71");
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
