using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class sdfadf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForManager_AlarmCode",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForManager_BgCheck",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForManager_KeyBuilding",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForManager_MobilePhone",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_15minutesInspection",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_CompanyEmail",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_Computer",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_Discord",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_Facebook",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_Gmail",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_ImportDashboard",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_PhoneExtension",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_Qnap",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_SaleDashboard",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice_WarehouseDashboard",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_3PL",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_BackBrace",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_ForkliftCheck",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_ForkliftTraining",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_Gloves",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_RFScanner",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_Radio",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse_SafetyVest",
                table: "EmpStartingInfo Forms");

            migrationBuilder.AddColumn<string>(
                name: "ForManager",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForOffice",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForWareHouse",
                table: "EmpStartingInfo Forms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForManager",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForOffice",
                table: "EmpStartingInfo Forms");

            migrationBuilder.DropColumn(
                name: "ForWareHouse",
                table: "EmpStartingInfo Forms");

            migrationBuilder.AddColumn<bool>(
                name: "ForManager_AlarmCode",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForManager_BgCheck",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForManager_KeyBuilding",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForManager_MobilePhone",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_15minutesInspection",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_CompanyEmail",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_Computer",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_Discord",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_Facebook",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_Gmail",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_ImportDashboard",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_PhoneExtension",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_Qnap",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_SaleDashboard",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForOffice_WarehouseDashboard",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_3PL",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_BackBrace",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_ForkliftCheck",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_ForkliftTraining",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_Gloves",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_RFScanner",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_Radio",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForWareHouse_SafetyVest",
                table: "EmpStartingInfo Forms",
                type: "bit",
                nullable: true);
        }
    }
}
