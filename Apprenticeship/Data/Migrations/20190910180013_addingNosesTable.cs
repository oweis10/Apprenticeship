using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apprenticeship.Data.Migrations
{
    public partial class addingNosesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Placements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Noses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PlacementStudentId = table.Column<string>(nullable: true),
                    PlacementSchoolMentorId = table.Column<string>(nullable: true),
                    PlacementWorkMentorId = table.Column<string>(nullable: true),
                    PlacementId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noses_Placements_PlacementStudentId_PlacementSchoolMentorId_PlacementWorkMentorId",
                        columns: x => new { x.PlacementStudentId, x.PlacementSchoolMentorId, x.PlacementWorkMentorId },
                        principalTable: "Placements",
                        principalColumns: new[] { "StudentId", "SchoolMentorId", "WorkMentorId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noses_PlacementStudentId_PlacementSchoolMentorId_PlacementWorkMentorId",
                table: "Noses",
                columns: new[] { "PlacementStudentId", "PlacementSchoolMentorId", "PlacementWorkMentorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noses");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Placements");
        }
    }
}
