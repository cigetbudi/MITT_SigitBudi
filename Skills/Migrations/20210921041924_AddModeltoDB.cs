using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skills.Migrations
{
    public partial class AddModeltoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillLevel",
                columns: table => new
                {
                    SkillLevelId = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    SkillLevelName = table.Column<string>(type: "nVarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevel", x => x.SkillLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nVarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nVarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nVarchar(500)", nullable: true),
                    BOD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nVarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Username);
                    table.ForeignKey(
                        name: "FK_UserProfile_User_Username",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserSkillId = table.Column<string>(type: "nVarchar(50)", nullable: false),
                    Username = table.Column<string>(type: "nVarchar(50)", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillLevelId = table.Column<string>(type: "nVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.UserSkillId);
                    table.ForeignKey(
                        name: "FK_UserSkills_SkillLevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevel",
                        principalColumn: "SkillLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_User_Username",
                        column: x => x.Username,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillLevelId",
                table: "UserSkills",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_Username",
                table: "UserSkills",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "SkillLevel");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
