using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class EmployeeStartingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeSend",
                table: "EmpStartingInfo Forms",
                newName: "UserRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRequest",
                table: "EmpStartingInfo Forms",
                newName: "EmployeeSend");
        }
    }
}
