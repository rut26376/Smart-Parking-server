using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarParking> CarParkings { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentsDetail> PaymentsDetails { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\רותי לוין\\parkingProject\\parking project\\DataBase.mdf\";Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarParking>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA6158160F7");

            entity.ToTable("Car_Parking");

            entity.Property(e => e.Level)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Row)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__CreditCa__A25C5AA6D54D6AB1");

            entity.Property(e => e.CreditCardNum)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CVV");
            entity.Property(e => e.DriverCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ValidityCard)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.DriverCodeNavigation).WithMany(p => p.CreditCards)
                .HasForeignKey(d => d.DriverCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreditCards_ToTable");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerPassword).HasName("PK__Manager__8368B07F9A15C283");

            entity.ToTable("Manager");

            entity.Property(e => e.ManagerPassword)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ManagerUserName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA654B2F6C1");

            entity.ToTable("Payment");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.CreditCardCodeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CreditCardCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_ToTable");
        });

        modelBuilder.Entity<PaymentsDetail>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Payments__A25C5AA6DDD82D87");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.PaymentCodeNavigation).WithMany(p => p.PaymentsDetails)
                .HasForeignKey(d => d.PaymentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentsDetails_ToTable");
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Routine__A25C5AA63C7F96F8");

            entity.ToTable("Routine");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.LicensePlateNavigation).WithMany(p => p.Routines)
                .HasForeignKey(d => d.LicensePlate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Routine_ToTable");

            entity.HasOne(d => d.ParkingCodeNavigation).WithMany(p => p.Routines)
                .HasForeignKey(d => d.ParkingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Routine_ToTable_1");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.LicensePlate);

            entity.Property(e => e.LicensePlate)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DriverCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.DriverCodeNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.DriverCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicles_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
