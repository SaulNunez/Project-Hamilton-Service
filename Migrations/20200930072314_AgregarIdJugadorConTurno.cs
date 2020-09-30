using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class AgregarIdJugadorConTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players");

            migrationBuilder.AddColumn<byte[]>(
                name: "Players",
                table: "Lobbies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_Players",
                table: "Lobbies",
                column: "Players",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lobbies_Players_Players",
                table: "Lobbies",
                column: "Players",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lobbies_Players_Players",
                table: "Lobbies");

            migrationBuilder.DropIndex(
                name: "IX_Lobbies_Players",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "Players",
                table: "Lobbies");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
