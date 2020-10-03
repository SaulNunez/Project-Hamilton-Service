using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class AgregarTimestampInicioDeResolverPuzzle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PuzzleStart",
                table: "Puzzles",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PuzzleStart",
                table: "Puzzles",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "NOW()");
        }
    }
}
