using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class LCfixstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HRStatus",
                table: "Lunch Correction Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HrDate",
                table: "Lunch Correction Forms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ManagerDate",
                table: "Lunch Correction Forms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ManagerStatus",
                table: "Lunch Correction Forms",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HRStatus",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "HrDate",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "ManagerDate",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "ManagerStatus",
                table: "Lunch Correction Forms");
        }
    }
}
