using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class addingNosToTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NosId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_NosId",
                table: "Tasks",
                column: "NosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Noses_NosId",
                table: "Tasks",
                column: "NosId",
                principalTable: "Noses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Noses_NosId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_NosId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "NosId",
                table: "Tasks");
        }
    }
}
