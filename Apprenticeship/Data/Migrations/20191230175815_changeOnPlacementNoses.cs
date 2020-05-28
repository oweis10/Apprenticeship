using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class changeOnPlacementNoses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noses_Placements_PlacementStudentId_PlacementSchoolMentorId_PlacementWorkMentorId",
                table: "Noses");

            migrationBuilder.DropForeignKey(
                name: "FK_Placements_AspNetUsers_SchoolMentorId",
                table: "Placements");

            migrationBuilder.DropForeignKey(
                name: "FK_Placements_AspNetUsers_StudentId",
                table: "Placements");

            migrationBuilder.DropForeignKey(
                name: "FK_Placements_AspNetUsers_WorkMentorId",
                table: "Placements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Placements",
                table: "Placements");

            migrationBuilder.DropIndex(
                name: "IX_Noses_PlacementStudentId_PlacementSchoolMentorId_PlacementWorkMentorId",
                table: "Noses");

            migrationBuilder.DropColumn(
                name: "PlacementId",
                table: "Noses");

            migrationBuilder.DropColumn(
                name: "PlacementSchoolMentorId",
                table: "Noses");

            migrationBuilder.RenameColumn(
                name: "PlacementWorkMentorId",
                table: "Noses",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "PlacementStudentId",
                table: "Noses",
                newName: "DeletedBy");

            migrationBuilder.AlterColumn<string>(
                name: "WorkMentorId",
                table: "Placements",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SchoolMentorId",
                table: "Placements",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Placements",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Placements",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Noses",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Noses",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Noses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Modified",
                table: "Noses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Placements",
                table: "Placements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlacementsNoses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlacementId = table.Column<long>(nullable: false),
                    NosId = table.Column<long>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementsNoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacementsNoses_Noses_NosId",
                        column: x => x.NosId,
                        principalTable: "Noses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacementsNoses_Placements_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Placements_StudentId",
                table: "Placements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementsNoses_NosId",
                table: "PlacementsNoses",
                column: "NosId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementsNoses_PlacementId",
                table: "PlacementsNoses",
                column: "PlacementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_AspNetUsers_SchoolMentorId",
                table: "Placements",
                column: "SchoolMentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_AspNetUsers_StudentId",
                table: "Placements",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_AspNetUsers_WorkMentorId",
                table: "Placements",
                column: "WorkMentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Placements_AspNetUsers_SchoolMentorId",
                table: "Placements");

            migrationBuilder.DropForeignKey(
                name: "FK_Placements_AspNetUsers_StudentId",
                table: "Placements");

            migrationBuilder.DropForeignKey(
                name: "FK_Placements_AspNetUsers_WorkMentorId",
                table: "Placements");

            migrationBuilder.DropTable(
                name: "PlacementsNoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Placements",
                table: "Placements");

            migrationBuilder.DropIndex(
                name: "IX_Placements_StudentId",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Placements");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Noses");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Noses");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Noses",
                newName: "PlacementWorkMentorId");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Noses",
                newName: "PlacementStudentId");

            migrationBuilder.AlterColumn<string>(
                name: "WorkMentorId",
                table: "Placements",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Placements",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolMentorId",
                table: "Placements",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlacementWorkMentorId",
                table: "Noses",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlacementStudentId",
                table: "Noses",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PlacementId",
                table: "Noses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PlacementSchoolMentorId",
                table: "Noses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Placements",
                table: "Placements",
                columns: new[] { "StudentId", "SchoolMentorId", "WorkMentorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Noses_PlacementStudentId_PlacementSchoolMentorId_PlacementWorkMentorId",
                table: "Noses",
                columns: new[] { "PlacementStudentId", "PlacementSchoolMentorId", "PlacementWorkMentorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Noses_Placements_PlacementStudentId_PlacementSchoolMentorId_PlacementWorkMentorId",
                table: "Noses",
                columns: new[] { "PlacementStudentId", "PlacementSchoolMentorId", "PlacementWorkMentorId" },
                principalTable: "Placements",
                principalColumns: new[] { "StudentId", "SchoolMentorId", "WorkMentorId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_AspNetUsers_SchoolMentorId",
                table: "Placements",
                column: "SchoolMentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_AspNetUsers_StudentId",
                table: "Placements",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Placements_AspNetUsers_WorkMentorId",
                table: "Placements",
                column: "WorkMentorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
