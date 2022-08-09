using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class DateJoined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateJoined",
                table: "Patrons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Patrons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Patrons");
        }
    }
}
