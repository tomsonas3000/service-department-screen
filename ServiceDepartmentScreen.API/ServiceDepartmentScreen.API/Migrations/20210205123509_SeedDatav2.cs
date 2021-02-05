using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceDepartmentScreen.API.Migrations
{
    public partial class SeedDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialists",
                columns: new[] { "SpecialistId", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Specialist1", "Specialist1", "123456", "spec1" },
                    { 2, "Specialist2", "Specialist2", "123456", "spec2" },
                    { 3, "Specialist3", "Specialist3", "123456", "spec3" },
                    { 4, "Specialist4", "Specialist4", "123456", "spec4" }
                });

            migrationBuilder.InsertData(
                table: "ReservationCodes",
                columns: new[] { "ReservationCodeId", "HasBegun", "HasEnded", "IsCancelled", "ReservationDate", "SpecialistId" },
                values: new object[,]
                {
                    { 2, false, false, false, new DateTime(2021, 2, 5, 16, 15, 25, 0, DateTimeKind.Unspecified), 1 },
                    { 4, false, false, false, new DateTime(2021, 2, 5, 12, 15, 25, 0, DateTimeKind.Unspecified), 1 },
                    { 1, false, false, true, new DateTime(2021, 2, 5, 22, 15, 25, 0, DateTimeKind.Unspecified), 2 },
                    { 5, false, true, false, new DateTime(2021, 2, 5, 10, 15, 25, 0, DateTimeKind.Unspecified), 2 },
                    { 3, false, false, false, new DateTime(2021, 2, 5, 18, 15, 25, 0, DateTimeKind.Unspecified), 3 },
                    { 6, false, false, false, new DateTime(2021, 2, 5, 22, 15, 25, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "SpecialistId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "SpecialistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "SpecialistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialists",
                keyColumn: "SpecialistId",
                keyValue: 3);
        }
    }
}
