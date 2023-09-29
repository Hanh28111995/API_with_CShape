using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateSend",
                table: "EmpStartingInfo Forms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeSend",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSend",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "EmployeeSend",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmpStartingInfo Forms");
        }
    }
}
