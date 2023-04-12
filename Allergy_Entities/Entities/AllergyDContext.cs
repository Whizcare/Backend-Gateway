using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntities.Entities;

public partial class AllergyDContext : DbContext
{
    public AllergyDContext()
    {
    }

    public AllergyDContext(DbContextOptions<AllergyDContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Server=tcp:sai-db-server.database.windows.net,1433;Initial Catalog=AllergyD;Persist Security Info=False;User ID=saikrishna;Password=Sai123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


    public virtual DbSet<Allergy> Allergies { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("PK__Allergy__5855FEB7877947C2");

            entity.ToTable("Allergy");

            entity.Property(e => e.AllergyId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Allergy_Id");
            entity.Property(e => e.AllergyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Allergy_Name");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
