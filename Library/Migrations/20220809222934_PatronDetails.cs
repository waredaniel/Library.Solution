using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class PatronDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Patrons",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<string>(
                name: "CityState",
                table: "Patrons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patrons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Patrons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityState",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Patrons",
                newName: "Name");
        }
    }
}
