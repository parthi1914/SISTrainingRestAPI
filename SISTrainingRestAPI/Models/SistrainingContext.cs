using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTrainingRestAPI.Models;

public partial class SistrainingContext : DbContext
{
    public SistrainingContext()
    {
    }

    public SistrainingContext(DbContextOptions<SistrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrainingStaff> TrainingStaffs { get; set; }

    public virtual DbSet<TrainingStudent> TrainingStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SISTraining;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Training__96D4AB179EE11918");

            entity.ToTable("TrainingStaff");

            entity.Property(e => e.StaffId).ValueGeneratedNever();
            entity.Property(e => e.Course).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.StaffName).HasMaxLength(150);
        });

        modelBuilder.Entity<TrainingStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3214EC0713D5E96B");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");

            entity.HasOne(d => d.Staff).WithMany(p => p.TrainingStudents)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__TrainingS__Staff__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
