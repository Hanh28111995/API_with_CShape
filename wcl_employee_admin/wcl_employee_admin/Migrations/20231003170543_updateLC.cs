using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class updateLC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForgetPunchForLunchHours",
                table: "Lunch Correction Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PayForOverLunchHour",
                table: "Lunch Correction Forms",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgetPunchForLunchHours",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "PayForOverLunchHour",
                table: "Lunch Correction Forms");
        }
    }
}
