using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class AgregarInformacionDeTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurnIndex",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnThrowResult",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnIndex",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TurnThrowResult",
                table: "Players");
        }
    }
}
