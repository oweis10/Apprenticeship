using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class taskStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Status = table.Column<int>(nullable: false),
                    TaskId = table.Column<long>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStatuses");
        }
    }
}
