using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class updateL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LunchCorrectionForgot",
                table: "Lunch Correction Forms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LunchCorrectionForgot",
                table: "Lunch Correction Forms",
                type: "bit",
                nullable: true);
        }
    }
}
