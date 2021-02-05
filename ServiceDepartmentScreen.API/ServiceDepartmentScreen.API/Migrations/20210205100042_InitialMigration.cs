using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceDepartmentScreen.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    SpecialistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.SpecialistId);
                });

            migrationBuilder.CreateTable(
                name: "ReservationCodes",
                columns: table => new
                {
                    ReservationCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    HasBegun = table.Column<bool>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    HasEnded = table.Column<bool>(nullable: false),
                    SpecialistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationCodes", x => x.ReservationCodeId);
                    table.ForeignKey(
                        name: "FK_ReservationCodes_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "SpecialistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCodes_SpecialistId",
                table: "ReservationCodes",
                column: "SpecialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationCodes");

            migrationBuilder.DropTable(
                name: "Specialists");
        }
    }
}
