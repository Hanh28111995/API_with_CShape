using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class statusUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnlineStatus",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineStatus",
                table: "AspNetUsers");
        }
    }
}
