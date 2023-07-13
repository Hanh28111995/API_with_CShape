using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class add4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSheet Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSheet_Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_Start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_End = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_Break_Start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_Break_End = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_TimeOff_Vacation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_TimeOff_Holiday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_TimeOff_45Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_TimeOff_noWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_TimeOff_note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet Forms", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheet Forms");
        }
    }
}
