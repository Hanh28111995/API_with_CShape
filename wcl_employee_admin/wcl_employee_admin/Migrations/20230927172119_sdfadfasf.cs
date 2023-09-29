using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class sdfadfasf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpStartingInfo Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartTimeOrFullTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamMembers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateWithNeed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ForOffice_Computer = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_CompanyEmail = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_Gmail = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_Facebook = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_Discord = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_Qnap = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_PhoneExtension = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_SaleDashboard = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_ImportDashboard = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_WarehouseDashboard = table.Column<bool>(type: "bit", nullable: true),
                    ForOffice_15minutesInspection = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_3PL = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_RFScanner = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_ForkliftTraining = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_SafetyVest = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_Gloves = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_Radio = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_BackBrace = table.Column<bool>(type: "bit", nullable: true),
                    ForWareHouse_ForkliftCheck = table.Column<bool>(type: "bit", nullable: true),
                    ForManager_KeyBuilding = table.Column<bool>(type: "bit", nullable: true),
                    ForManager_AlarmCode = table.Column<bool>(type: "bit", nullable: true),
                    ForManager_BgCheck = table.Column<bool>(type: "bit", nullable: true),
                    ForManager_MobilePhone = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpStartingInfo Forms", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpStartingInfo Forms");
        }
    }
}
