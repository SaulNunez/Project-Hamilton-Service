using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class AgregarStatsOMovimientosAPuzzles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BraveryStatDiff",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntelligenceStatDiff",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewFloor",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewX",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewY",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhysicalStatDiff",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SanityStatDiff",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BraveryStatDiff",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "IntelligenceStatDiff",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "NewFloor",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "NewX",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "NewY",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "PhysicalStatDiff",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "SanityStatDiff",
                table: "Puzzles");
        }
    }
}
