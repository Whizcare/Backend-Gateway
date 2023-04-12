using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Audit_DataEntites.Entity;

public partial class AuditDbContext : DbContext
{
    public AuditDbContext()
    {
    }

    public AuditDbContext(DbContextOptions<AuditDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditDatum> AuditData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:dhanushreddy.database.windows.net,1433;Initial Catalog=AuditDb;Persist Security Info=False;User ID=dhanush;Password=Password@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auditDat__3213E83F376B5350");

            entity.ToTable("auditData");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AdditioanlDetails).IsUnicode(false);
            entity.Property(e => e.Allergies).IsUnicode(false);
            entity.Property(e => e.BloodPressure)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Dignosis).IsUnicode(false);
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientnameFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientnameLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
