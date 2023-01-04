﻿// <auto-generated />
using System;
using BloodeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodeAPI.Migrations
{
    [DbContext(typeof(BlooddonateContext))]
    partial class BlooddonateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodeAPI.Models.DeviceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Ostype")
                        .HasColumnType("int")
                        .HasColumnName("OSType");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasComment("This device is for which user");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DeviceInfo", (string)null);
                });

            modelBuilder.Entity("BloodeAPI.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Request", (string)null);
                });

            modelBuilder.Entity("BloodeAPI.Models.RequestDonar", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("RequestDonars");
                });

            modelBuilder.Entity("BloodeAPI.Models.RequestHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestHistory", (string)null);
                });

            modelBuilder.Entity("BloodeAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroup")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime")
                        .HasColumnName("DOB");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", t =>
                        {
                            t.HasComment("All of the basic user info stores here");
                        });
                });

            modelBuilder.Entity("BloodeAPI.Models.DeviceInfo", b =>
                {
                    b.HasOne("BloodeAPI.Models.User", "User")
                        .WithMany("DeviceInfos")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_DeviceInfo_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloodeAPI.Models.Request", b =>
                {
                    b.HasOne("BloodeAPI.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Request_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloodeAPI.Models.RequestDonar", b =>
                {
                    b.HasOne("BloodeAPI.Models.Request", "Request")
                        .WithMany("RequestDonars")
                        .HasForeignKey("RequestId")
                        .IsRequired()
                        .HasConstraintName("FK_RequestDonars_Request");

                    b.HasOne("BloodeAPI.Models.User", "User")
                        .WithMany("RequestDonars")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_RequestDonars_Users");

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BloodeAPI.Models.RequestHistory", b =>
                {
                    b.HasOne("BloodeAPI.Models.Request", "Request")
                        .WithMany("RequestHistories")
                        .HasForeignKey("RequestId")
                        .HasConstraintName("FK_RequestHistory_Request");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("BloodeAPI.Models.Request", b =>
                {
                    b.Navigation("RequestDonars");

                    b.Navigation("RequestHistories");
                });

            modelBuilder.Entity("BloodeAPI.Models.User", b =>
                {
                    b.Navigation("DeviceInfos");

                    b.Navigation("RequestDonars");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
