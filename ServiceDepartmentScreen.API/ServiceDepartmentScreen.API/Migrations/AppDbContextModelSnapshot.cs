﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceDepartmentScreen.API.Models;

namespace ServiceDepartmentScreen.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceDepartmentScreen.Shared.ReservationCode", b =>
                {
                    b.Property<int>("ReservationCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SpecialistId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ReservationCodeId");

                    b.HasIndex("SpecialistId");

                    b.ToTable("ReservationCodes");

                    b.HasData(
                        new
                        {
                            ReservationCodeId = 1,
                            ReservationDate = new DateTime(2021, 2, 5, 22, 15, 25, 0, DateTimeKind.Unspecified),
                            SpecialistId = 2,
                            Status = 0
                        },
                        new
                        {
                            ReservationCodeId = 2,
                            ReservationDate = new DateTime(2021, 2, 5, 16, 15, 25, 0, DateTimeKind.Unspecified),
                            SpecialistId = 1,
                            Status = 3
                        },
                        new
                        {
                            ReservationCodeId = 3,
                            ReservationDate = new DateTime(2021, 2, 5, 18, 15, 25, 0, DateTimeKind.Unspecified),
                            SpecialistId = 3,
                            Status = 0
                        },
                        new
                        {
                            ReservationCodeId = 4,
                            ReservationDate = new DateTime(2021, 2, 5, 12, 15, 25, 0, DateTimeKind.Unspecified),
                            SpecialistId = 1,
                            Status = 1
                        },
                        new
                        {
                            ReservationCodeId = 5,
                            ReservationDate = new DateTime(2021, 2, 5, 10, 15, 25, 0, DateTimeKind.Unspecified),
                            SpecialistId = 2,
                            Status = 0
                        },
                        new
                        {
                            ReservationCodeId = 6,
                            ReservationDate = new DateTime(2021, 2, 5, 22, 15, 25, 0, DateTimeKind.Unspecified),
                            SpecialistId = 3,
                            Status = 1
                        });
                });

            modelBuilder.Entity("ServiceDepartmentScreen.Shared.Specialist", b =>
                {
                    b.Property<int>("SpecialistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialistId");

                    b.ToTable("Specialists");

                    b.HasData(
                        new
                        {
                            SpecialistId = 1,
                            FirstName = "Specialist1",
                            LastName = "Specialist1",
                            Password = "123456",
                            Username = "spec1"
                        },
                        new
                        {
                            SpecialistId = 2,
                            FirstName = "Specialist2",
                            LastName = "Specialist2",
                            Password = "123456",
                            Username = "spec2"
                        },
                        new
                        {
                            SpecialistId = 3,
                            FirstName = "Specialist3",
                            LastName = "Specialist3",
                            Password = "123456",
                            Username = "spec3"
                        },
                        new
                        {
                            SpecialistId = 4,
                            FirstName = "Specialist4",
                            LastName = "Specialist4",
                            Password = "123456",
                            Username = "spec4"
                        });
                });

            modelBuilder.Entity("ServiceDepartmentScreen.Shared.ReservationCode", b =>
                {
                    b.HasOne("ServiceDepartmentScreen.Shared.Specialist", "Specialist")
                        .WithMany()
                        .HasForeignKey("SpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
