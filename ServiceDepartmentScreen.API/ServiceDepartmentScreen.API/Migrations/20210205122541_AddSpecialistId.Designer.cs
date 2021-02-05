﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceDepartmentScreen.API.Models;

namespace ServiceDepartmentScreen.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210205122541_AddSpecialistId")]
    partial class AddSpecialistId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceDepartmentScreen.API.Models.ReservationCode", b =>
                {
                    b.Property<int>("ReservationCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HasBegun")
                        .HasColumnType("bit");

                    b.Property<bool>("HasEnded")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SpecialistId")
                        .HasColumnType("int");

                    b.HasKey("ReservationCodeId");

                    b.HasIndex("SpecialistId");

                    b.ToTable("ReservationCodes");
                });

            modelBuilder.Entity("ServiceDepartmentScreen.API.Models.Specialist", b =>
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
                });

            modelBuilder.Entity("ServiceDepartmentScreen.API.Models.ReservationCode", b =>
                {
                    b.HasOne("ServiceDepartmentScreen.API.Models.Specialist", "Specialist")
                        .WithMany()
                        .HasForeignKey("SpecialistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}