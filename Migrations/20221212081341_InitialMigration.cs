using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akvelon_Task_Manager.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    ProjectPriority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskStatus = table.Column<int>(type: "int", nullable: false),
                    TaskPriority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompletionDate", "ProjectName", "ProjectPriority", "ProjectStatus", "StartDate" },
                values: new object[] { 1, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Api Project", 1, 0, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompletionDate", "ProjectName", "ProjectPriority", "ProjectStatus", "StartDate" },
                values: new object[] { 2, new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client Server Project", 2, 0, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompletionDate", "ProjectName", "ProjectPriority", "ProjectStatus", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Machine Learning Project", 3, 0, new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ProjectId", "TaskName", "TaskPriority", "TaskStatus" },
                values: new object[] { 1, 2, "Create Models", 1, 0 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ProjectId", "TaskName", "TaskPriority", "TaskStatus" },
                values: new object[] { 2, 3, "Collect Dataset", 2, 0 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ProjectId", "TaskName", "TaskPriority", "TaskStatus" },
                values: new object[] { 3, 1, "Create From CLI", 3, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
