using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class IncioPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    X = table.Column<int>(nullable: false, defaultValue: 0),
                    Y = table.Column<int>(nullable: false, defaultValue: 0),
                    Floor = table.Column<int>(nullable: false, defaultValue: 0),
                    Sanity = table.Column<int>(nullable: false),
                    Physical = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Bravery = table.Column<int>(nullable: false),
                    AvailableMoves = table.Column<int>(nullable: false),
                    CharacterPrototypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LobbyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puzzles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PuzzleStart = table.Column<DateTime>(nullable: false),
                    PuzzleEnd = table.Column<DateTime>(nullable: false),
                    PlayersId = table.Column<Guid>(nullable: false),
                    PuzzlePrototype = table.Column<string>(nullable: true),
                    SolvedCorrectly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlayersId = table.Column<Guid>(nullable: false),
                    Prototype = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    OnProgress = table.Column<bool>(nullable: false),
                    Players = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Lobbies_Players_Players",
                        column: x => x.Players,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    LobbyId = table.Column<string>(nullable: true),
                    RoomProtoype = table.Column<string>(nullable: true),
                    PlayerActionAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayersId",
                table: "Items",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_Players",
                table: "Lobbies",
                column: "Players",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LobbyId",
                table: "Rooms",
                column: "LobbyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Puzzles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
