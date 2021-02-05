using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ReservationCode> ReservationCodes { get; set; }
        public DbSet<Specialist> Specialists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Specialist>().HasData(new Specialist
            {
                SpecialistId = 1,
                FirstName = "Specialist1",
                LastName = "Specialist1",
                Password = "123456",
                Username = "spec1"
            });
            modelBuilder.Entity<Specialist>().HasData(new Specialist
            {
                SpecialistId = 2,
                FirstName = "Specialist2",
                LastName = "Specialist2",
                Password = "123456",
                Username = "spec2"
            });
            modelBuilder.Entity<Specialist>().HasData(new Specialist
            {
                SpecialistId = 3,
                FirstName = "Specialist3",
                LastName = "Specialist3",
                Password = "123456",
                Username = "spec3"
            });
            modelBuilder.Entity<Specialist>().HasData(new Specialist
            {
                SpecialistId = 4,
                FirstName = "Specialist4",
                LastName = "Specialist4",
                Password = "123456",
                Username = "spec4"
            });

            modelBuilder.Entity<ReservationCode>().HasData(new ReservationCode
            {
                ReservationCodeId = 1,
                ReservationDate = new DateTime(2021, 02, 05, 22, 15, 25),
                Status = Status.Active,
                SpecialistId = 2
            });
            modelBuilder.Entity<ReservationCode>().HasData(new ReservationCode
            {
                ReservationCodeId = 2,
                ReservationDate = new DateTime(2021, 02, 05, 16, 15, 25),
                Status = Status.Cancelled,
                SpecialistId = 1
            });
            modelBuilder.Entity<ReservationCode>().HasData(new ReservationCode
            {
                ReservationCodeId = 3,
                ReservationDate = new DateTime(2021, 02, 05, 18, 15, 25),
                Status = Status.Active,
                SpecialistId = 3
            });
            modelBuilder.Entity<ReservationCode>().HasData(new ReservationCode
            {
                ReservationCodeId = 4,
                ReservationDate = new DateTime(2021, 02, 05, 12, 15, 25),
                Status = Status.Upcoming,
                SpecialistId = 1
            });
            modelBuilder.Entity<ReservationCode>().HasData(new ReservationCode
            {
                ReservationCodeId = 5,
                ReservationDate = new DateTime(2021, 02, 05, 10, 15, 25),
                Status = Status.Active,
                SpecialistId = 2
            });
            modelBuilder.Entity<ReservationCode>().HasData(new ReservationCode
            {
                ReservationCodeId = 6,
                ReservationDate = new DateTime(2021, 02, 05, 22, 15, 25),
                Status = Status.Upcoming,
                SpecialistId = 3
            });
        }
    }
}
