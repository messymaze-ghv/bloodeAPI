using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BloodeAPI.Models;

public partial class BlooddonateContext : DbContext
{
    public BlooddonateContext()
    {
    }

    public BlooddonateContext(DbContextOptions<BlooddonateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestHistory> RequestHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:bloode.database.windows.net,1433;Initial Catalog=blooddonate;Persist Security Info=False;User ID=harsha;Password=Sripadm@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceInfo>(entity =>
        {
            entity.ToTable("DeviceInfo");

            entity.Property(e => e.DeviceId).HasMaxLength(50);
            entity.Property(e => e.Ostype).HasColumnName("OSType");
            entity.Property(e => e.UserId).HasComment("This device is for which user");

            entity.HasOne(d => d.User).WithMany(p => p.DeviceInfos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeviceInfo_Users");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Users");
        });

        modelBuilder.Entity<RequestHistory>(entity =>
        {
            entity.ToTable("RequestHistory");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestHistories)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_RequestHistory_Request");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("All of the basic user info stores here"));

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
