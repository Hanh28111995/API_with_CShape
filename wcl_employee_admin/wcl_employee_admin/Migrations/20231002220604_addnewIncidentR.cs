using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class addnewIncidentR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Incident Report Forms",
                newName: "Fullname");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Incident Report Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Incident Report Forms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Incident Report Forms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Incident Report Forms");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Incident Report Forms",
                newName: "Reason");
        }
    }
}
