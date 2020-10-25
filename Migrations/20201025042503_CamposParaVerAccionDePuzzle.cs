using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class CamposParaVerAccionDePuzzle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NewY",
                table: "Puzzles",
                nullable: false,
                defaultValue: -1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "NewX",
                table: "Puzzles",
                nullable: false,
                defaultValue: -1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "NewFloor",
                table: "Puzzles",
                nullable: false,
                defaultValue: -1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "ModifiesPosition",
                table: "Puzzles",
                nullable: false,
                computedColumnSql: "[NewX] != -1 OR [NewY] != -1 OR [NewFloor] != -1");

            migrationBuilder.AddColumn<bool>(
                name: "ModifiesStats",
                table: "Puzzles",
                nullable: false,
                computedColumnSql: "[BraveryStatDiff] > 0 OR [IntelligenceStatDiff] > 0 OR [SanityStatDiff] > 0 OR [PhysicalStatDiff] > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiesPosition",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "ModifiesStats",
                table: "Puzzles");

            migrationBuilder.AlterColumn<int>(
                name: "NewY",
                table: "Puzzles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "NewX",
                table: "Puzzles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "NewFloor",
                table: "Puzzles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: -1);
        }
    }
}
