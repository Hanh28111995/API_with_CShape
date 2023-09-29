using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class EmployeeStartingInfor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmpStartingInfo Forms");

            migrationBuilder.AddColumn<bool>(
                name: "ITfeedbackStatus",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SendITStatus",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ITfeedbackStatus",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "SendITStatus",
                table: "EmpStartingInfo Forms");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
