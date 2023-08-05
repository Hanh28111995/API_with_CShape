using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class addTimesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalTime",
                table: "TimeSheet Forms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "TimeSheet Forms");
        }
    }
}
