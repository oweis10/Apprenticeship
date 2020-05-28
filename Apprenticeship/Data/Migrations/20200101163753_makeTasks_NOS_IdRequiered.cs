using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class makeTasks_NOS_IdRequiered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Noses_NosId",
                table: "Tasks");

            migrationBuilder.AlterColumn<long>(
                name: "NosId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Noses_NosId",
                table: "Tasks",
                column: "NosId",
                principalTable: "Noses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Noses_NosId",
                table: "Tasks");

            migrationBuilder.AlterColumn<long>(
                name: "NosId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Noses_NosId",
                table: "Tasks",
                column: "NosId",
                principalTable: "Noses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
