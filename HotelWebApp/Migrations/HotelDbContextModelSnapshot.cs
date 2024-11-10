﻿// <auto-generated />
using System;
using HotelWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelWebApp.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelWebApp.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BookingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<string>("BookingReference")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasComputedColumnSql("((CONVERT([varchar](10),[BookingID])+CONVERT([varchar](10),[CustomerID]))+CONVERT([varchar](10),[RoomID]))", false);

                    b.Property<DateOnly>("CheckInDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CheckOutDate")
                        .HasColumnType("date");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<bool>("DepositMade")
                        .HasColumnType("bit");

                    b.Property<string>("DepositMethod")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("DepositStatus")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    b.HasKey("BookingId")
                        .HasName("PK__Booking__73951ACD57E391D0");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("HotelWebApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompanyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("CompanyId")
                        .HasName("PK__Company__2D971C4C72B14192");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("HotelWebApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int")
                        .HasColumnName("AgencyID");

                    b.Property<string>("BookingReference")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B8EE40397A");

                    b.HasIndex("AgencyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex(new[] { "BookingReference" }, "UQ__Customer__F9B66F612823BA91")
                        .IsUnique()
                        .HasFilter("[BookingReference] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HotelWebApp.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoleId")
                        .HasName("PK__Roles__8AFACE3A88C8B8B5");

                    b.HasIndex(new[] { "RoleName" }, "UQ__Roles__8A2B6160372C384A")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HotelWebApp.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<bool>("BookingAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("CarPark")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("RoomTypeID");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    b.HasKey("RoomId")
                        .HasName("PK__Room__32863919BE1D17FF");

                    b.HasIndex("RoomTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("HotelWebApp.Models.RoomStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("StatusId")
                        .HasName("PK__RoomStat__C8EE2043373885FD");

                    b.ToTable("RoomStatus", (string)null);
                });

            modelBuilder.Entity("HotelWebApp.Models.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<int>("MaxOccupants")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoomTypeId")
                        .HasName("PK__RoomType__BCC8961152E56DBE");

                    b.ToTable("RoomType", (string)null);
                });

            modelBuilder.Entity("HotelWebApp.Models.TravelAgency", b =>
                {
                    b.Property<int>("AgencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgencyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgencyId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AgencyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("AgencyId")
                        .HasName("PK__TravelAg__95C546FBB737FBB4");

                    b.ToTable("TravelAgency", (string)null);
                });

            modelBuilder.Entity("HotelWebApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("UserName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(61)
                        .IsUnicode(false)
                        .HasColumnType("varchar(61)")
                        .HasComputedColumnSql("(lower((left([FirstName],(1))+[LastName])+CONVERT([varchar](10),[UserID])))", true);

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCAC26E282A5");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelWebApp.Models.Booking", b =>
                {
                    b.HasOne("HotelWebApp.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Booking__Custome__0C85DE4D");

                    b.HasOne("HotelWebApp.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK__Booking__RoomID__0D7A0286");

                    b.Navigation("Customer");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelWebApp.Models.Customer", b =>
                {
                    b.HasOne("HotelWebApp.Models.TravelAgency", "Agency")
                        .WithMany("Customers")
                        .HasForeignKey("AgencyId")
                        .HasConstraintName("FK__Customers__Agenc__02084FDA");

                    b.HasOne("HotelWebApp.Models.Company", "Company")
                        .WithMany("Customers")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK__Customers__Compa__01142BA1");

                    b.Navigation("Agency");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelWebApp.Models.Room", b =>
                {
                    b.HasOne("HotelWebApp.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Room__RoomTypeID__08B54D69");

                    b.HasOne("HotelWebApp.Models.RoomStatus", "Status")
                        .WithMany("Rooms")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Room__StatusID__09A971A2");

                    b.Navigation("RoomType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("HotelWebApp.Models.User", b =>
                {
                    b.HasOne("HotelWebApp.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Users__RoleID__797309D9");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HotelWebApp.Models.Company", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("HotelWebApp.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelWebApp.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("HotelWebApp.Models.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelWebApp.Models.RoomStatus", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelWebApp.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelWebApp.Models.TravelAgency", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
