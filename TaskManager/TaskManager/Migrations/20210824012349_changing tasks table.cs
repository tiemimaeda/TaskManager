using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class changingtaskstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TASK");

            migrationBuilder.CreateTable(
                name: "ASSIGNMENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Complexity = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSIGNMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ASSIGNMENT_APPLICATION_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "APPLICATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ASSIGNMENT_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSIGNMENT_ApplicationId",
                table: "ASSIGNMENT",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ASSIGNMENT_UserId",
                table: "ASSIGNMENT",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSIGNMENT");

            migrationBuilder.CreateTable(
                name: "TASK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Complexity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TASK_APPLICATION_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "APPLICATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TASK_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TASK_ApplicationId",
                table: "TASK",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_TASK_UserId",
                table: "TASK",
                column: "UserId");
        }
    }
}
