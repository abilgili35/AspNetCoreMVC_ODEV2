using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class HospitalAutomationNtierContext : DbContext
{
    public HospitalAutomationNtierContext()
    {
    }

    public HospitalAutomationNtierContext(DbContextOptions<HospitalAutomationNtierContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnalysisResult> AnalysisResults { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientInfo> PatientInfos { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=ABILGILI\\SQLEXPRESS;database=HospitalAutomationNTier;Integrated Security=SSPI;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalysisResult>(entity =>
        {
            entity.HasIndex(e => e.PatientId, "IX_AnalysisResults_PatientId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FileLink).HasMaxLength(255);

            entity.HasOne(d => d.Patient).WithMany(p => p.AnalysisResults).HasForeignKey(d => d.PatientId);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => new { e.DoctorId, e.PatientId });

            entity.HasIndex(e => e.PatientId, "IX_Appointments_PatientId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments).HasForeignKey(d => d.DoctorId);

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments).HasForeignKey(d => d.PatientId);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Profession).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<PatientInfo>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PatientInfo).HasForeignKey<PatientInfo>(d => d.Id);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => e.PatientId, "IX_Payments_PatientId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("money");

            entity.HasOne(d => d.Patient).WithMany(p => p.Payments).HasForeignKey(d => d.PatientId);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Room).HasForeignKey<Room>(d => d.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
