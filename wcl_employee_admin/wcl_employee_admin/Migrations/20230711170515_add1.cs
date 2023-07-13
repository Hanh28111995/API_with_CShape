using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class add1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee Complaint Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateComplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeWitness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerStatus = table.Column<bool>(type: "bit", nullable: true),
                    SubmitDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HrDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee Complaint Forms", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee Complaint Forms");
        }
    }
}
