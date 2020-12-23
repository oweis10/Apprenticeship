using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class addTaskGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaskGroup",
                table: "Tasks",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskGroup",
                table: "Tasks");
        }
    }
}
