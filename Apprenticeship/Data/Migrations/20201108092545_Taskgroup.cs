using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class Taskgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TaskGroup",
                table: "Tasks",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskGroup",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    TaskId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => new { x.TaskId, x.Status });
                    table.ForeignKey(
                        name: "FK_TaskStatuses_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
