using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateComplain",
                table: "Employee Complaint Forms",
                newName: "DescribeSolution");

            migrationBuilder.AddColumn<string>(
                name: "DateSubmit",
                table: "Employee Complaint Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescribeComment",
                table: "Employee Complaint Forms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSubmit",
                table: "Employee Complaint Forms");

            migrationBuilder.DropColumn(
                name: "DescribeComment",
                table: "Employee Complaint Forms");

            migrationBuilder.RenameColumn(
                name: "DescribeSolution",
                table: "Employee Complaint Forms",
                newName: "DateComplain");
        }
    }
}
