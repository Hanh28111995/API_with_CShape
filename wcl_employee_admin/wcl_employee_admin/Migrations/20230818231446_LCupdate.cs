using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class LCupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Lunch Correction Forms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
