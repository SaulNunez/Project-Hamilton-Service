using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class CambiarThrowRequestParaAgregarMasInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lobbies_Players_Players",
                table: "Lobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_ThrowRequest_AvailableThrowRequestId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_AvailableThrowRequestId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Lobbies_Players",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "AvailableThrowRequestId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Players",
                table: "Lobbies");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:throw_motive", "movement,item")
                .Annotation("Npgsql:Enum:throw_types", "one_six_face_dice,two_six_face_dice")
                .OldAnnotation("Npgsql:Enum:throw_motive", "movement,item");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "ThrowRequest",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentPlayerId",
                table: "Lobbies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfRequest",
                table: "ThrowRequest",
                nullable: false,
                computedColumnSql: "NOW()");

            migrationBuilder.CreateIndex(
                name: "IX_ThrowRequest_PlayerId",
                table: "ThrowRequest",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LobbyId",
                table: "Players",
                column: "LobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players",
                column: "LobbyId",
                principalTable: "Lobbies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThrowRequest_Players_PlayerId",
                table: "ThrowRequest",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Lobbies_LobbyId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_ThrowRequest_Players_PlayerId",
                table: "ThrowRequest");

            migrationBuilder.DropIndex(
                name: "IX_ThrowRequest_PlayerId",
                table: "ThrowRequest");

            migrationBuilder.DropIndex(
                name: "IX_Players_LobbyId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "ThrowRequest");

            migrationBuilder.DropColumn(
                name: "TimeOfRequest",
                table: "ThrowRequest");

            migrationBuilder.DropColumn(
                name: "CurrentPlayerId",
                table: "Lobbies");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:throw_motive", "movement,item")
                .OldAnnotation("Npgsql:Enum:throw_motive", "movement,item")
                .OldAnnotation("Npgsql:Enum:throw_types", "one_six_face_dice,two_six_face_dice");

            migrationBuilder.AddColumn<Guid>(
                name: "AvailableThrowRequestId",
                table: "Players",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Players",
                table: "Lobbies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AvailableThrowRequestId",
                table: "Players",
                column: "AvailableThrowRequestId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Players_ThrowRequest_AvailableThrowRequestId",
                table: "Players",
                column: "AvailableThrowRequestId",
                principalTable: "ThrowRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
