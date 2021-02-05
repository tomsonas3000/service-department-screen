using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceDepartmentScreen.API.Migrations
{
    public partial class UpdateStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBegun",
                table: "ReservationCodes");

            migrationBuilder.DropColumn(
                name: "HasEnded",
                table: "ReservationCodes");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "ReservationCodes");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReservationCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 2,
                column: "Status",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 6,
                column: "Status",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReservationCodes");

            migrationBuilder.AddColumn<bool>(
                name: "HasBegun",
                table: "ReservationCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasEnded",
                table: "ReservationCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "ReservationCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 1,
                column: "IsCancelled",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReservationCodes",
                keyColumn: "ReservationCodeId",
                keyValue: 5,
                column: "HasEnded",
                value: true);
        }
    }
}
