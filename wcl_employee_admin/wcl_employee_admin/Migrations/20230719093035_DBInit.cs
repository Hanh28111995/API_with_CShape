using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wcl_employee_admin.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photourl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirmnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cardnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Netsalary = table.Column<int>(type: "int", nullable: true),
                    Grosssalary = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contracttype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Marital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datestart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee Complaint Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeWitness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeSolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerStatus = table.Column<bool>(type: "bit", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee Complaint Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Incident Report Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIncident = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Witness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerStatus = table.Column<bool>(type: "bit", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident Report Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Injury Report Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonOccur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInvolved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherIncident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesOfInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyAffected_Right = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyAffected_Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareProvided = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injury Report Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lunch Correction Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonOccur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInvolved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherIncident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesOfInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyAffected_Right = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyAffected_Left = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareProvided = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunch Correction Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Miss Punch Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PunchIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PunchOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LunchIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LunchOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerStatus = table.Column<bool>(type: "bit", nullable: true),
                    ManagerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miss Punch Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Time Off Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOffStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOffEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverWorker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerStatus = table.Column<bool>(type: "bit", nullable: true),
                    CoworkerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoworkerStatus = table.Column<bool>(type: "bit", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time Off Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheet Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSheet_Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSheet_Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSheet_End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSheet_Break_Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSheet_Break_End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSheet_Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSheet_TimeOff_Vacation = table.Column<int>(type: "int", nullable: false),
                    TimeSheet_TimeOff_Holiday = table.Column<int>(type: "int", nullable: false),
                    TimeSheet_TimeOff_45Day = table.Column<int>(type: "int", nullable: false),
                    TimeSheet_TimeOff_noWork = table.Column<int>(type: "int", nullable: false),
                    TimeSheet_TimeOff_note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VTO Forms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerStatus = table.Column<bool>(type: "bit", nullable: true),
                    HrDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRStatus = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VTO Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employee Complaint Forms");

            migrationBuilder.DropTable(
                name: "Incident Report Forms");

            migrationBuilder.DropTable(
                name: "Injury Report Forms");

            migrationBuilder.DropTable(
                name: "Lunch Correction Forms");

            migrationBuilder.DropTable(
                name: "Miss Punch Forms");

            migrationBuilder.DropTable(
                name: "Time Off Forms");

            migrationBuilder.DropTable(
                name: "TimeSheet Forms");

            migrationBuilder.DropTable(
                name: "VTO Forms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
