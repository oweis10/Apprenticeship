using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class removeTaskGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskGroup",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaskGroup",
                table: "Tasks",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
