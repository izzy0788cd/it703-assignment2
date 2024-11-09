using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApp.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomStatus> RoomStatuses { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<TravelAgency> TravelAgencies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KAONTU1\\SQLEXPRESS;Database=0_IT703_Assignment_No2;Trusted_Connection=True;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD57E391D0");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingReference)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComputedColumnSql("((CONVERT([varchar](10),[BookingID])+CONVERT([varchar](10),[CustomerID]))+CONVERT([varchar](10),[RoomID]))", false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DepositMethod)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.DepositStatus)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Custome__0C85DE4D");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__RoomID__0D7A0286");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971C4C72B14192");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8EE40397A");

            entity.HasIndex(e => e.BookingReference, "UQ__Customer__F9B66F612823BA91").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.BookingReference)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Agency).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AgencyId)
                .HasConstraintName("FK__Customers__Agenc__02084FDA");

            entity.HasOne(d => d.Company).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Customers__Compa__01142BA1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A88C8B8B5");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160372C384A").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__32863919BE1D17FF");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.CarPark)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__RoomTypeID__08B54D69");

            entity.HasOne(d => d.Status).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__StatusID__09A971A2");
        });

        modelBuilder.Entity<RoomStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__RoomStat__C8EE2043373885FD");

            entity.ToTable("RoomStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC8961152E56DBE");

            entity.ToTable("RoomType");

            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TravelAgency>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("PK__TravelAg__95C546FBB737FBB4");

            entity.ToTable("TravelAgency");

            entity.Property(e => e.AgencyId).HasColumnName("AgencyID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AgencyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC26E282A5");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName)
                .HasMaxLength(61)
                .IsUnicode(false)
                .HasComputedColumnSql("(lower((left([FirstName],(1))+[LastName])+CONVERT([varchar](10),[UserID])))", true);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__797309D9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
