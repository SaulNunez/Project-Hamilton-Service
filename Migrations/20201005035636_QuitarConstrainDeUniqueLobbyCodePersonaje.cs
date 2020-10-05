using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class QuitarConstrainDeUniqueLobbyCodePersonaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_CharacterPrototypeId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_LobbyId",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Players_CharacterPrototypeId",
                table: "Players",
                column: "CharacterPrototypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_LobbyId",
                table: "Players",
                column: "LobbyId",
                unique: true);
        }
    }
}
