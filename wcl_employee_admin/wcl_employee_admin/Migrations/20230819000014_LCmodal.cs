using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class LCmodal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "BodyAffected_Left",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "BodyAffected_Right",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "CareProvided",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "CauseBy",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "DesOfInjury",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Hospital",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "Lunch Correction Forms");

            migrationBuilder.DropColumn(
                name: "NatureOfInjury",
                table: "Lunch Correction Forms");

            migrationBuilder.RenameColumn(
                name: "ReasonOccur",
                table: "Lunch Correction Forms",
                newName: "Reason_Options");

            migrationBuilder.RenameColumn(
                name: "OtherInvolved",
                table: "Lunch Correction Forms",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "OtherInjury",
                table: "Lunch Correction Forms",
                newName: "Other_Reason");

            migrationBuilder.RenameColumn(
                name: "OtherIncident",
                table: "Lunch Correction Forms",
                newName: "Manager");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Lunch Correction Forms",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "HrDate",
                table: "Lunch Correction Forms",
                newName: "LunchCorrection_start");

            migrationBuilder.RenameColumn(
                name: "HRStatus",
                table: "Lunch Correction Forms",
                newName: "LunchCorrectionForgot");

            migrationBuilder.RenameColumn(
                name: "DateSubmit",
                table: "Lunch Correction Forms",
                newName: "LunchCorrection_end");

            migrationBuilder.RenameColumn(
                name: "DateOfAccident",
                table: "Lunch Correction Forms",
                newName: "LunchCorrection_date_overtime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason_Options",
                table: "Lunch Correction Forms",
                newName: "ReasonOccur");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Lunch Correction Forms",
                newName: "OtherInvolved");

            migrationBuilder.RenameColumn(
                name: "Other_Reason",
                table: "Lunch Correction Forms",
                newName: "OtherInjury");

            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "Lunch Correction Forms",
                newName: "OtherIncident");

            migrationBuilder.RenameColumn(
                name: "LunchCorrection_start",
                table: "Lunch Correction Forms",
                newName: "HrDate");

            migrationBuilder.RenameColumn(
                name: "LunchCorrection_end",
                table: "Lunch Correction Forms",
                newName: "DateSubmit");

            migrationBuilder.RenameColumn(
                name: "LunchCorrection_date_overtime",
                table: "Lunch Correction Forms",
                newName: "DateOfAccident");

            migrationBuilder.RenameColumn(
                name: "LunchCorrectionForgot",
                table: "Lunch Correction Forms",
                newName: "HRStatus");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Lunch Correction Forms",
                newName: "Note");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyAffected_Left",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyAffected_Right",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CareProvided",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CauseBy",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesOfInjury",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hospital",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Insurance",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatureOfInjury",
                table: "Lunch Correction Forms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
