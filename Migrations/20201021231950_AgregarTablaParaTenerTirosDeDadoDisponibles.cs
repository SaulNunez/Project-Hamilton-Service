using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectHamiltonService.Models;

namespace ProjectHamiltonService.Migrations
{
    public partial class AgregarTablaParaTenerTirosDeDadoDisponibles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:throw_motive", "movement,item");

            migrationBuilder.AddColumn<Guid>(
                name: "AvailableThrowRequestId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThrowRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Motive = table.Column<ThrowMotive>(nullable: false),
                    Dice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThrowRequest", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AvailableThrowRequestId",
                table: "Players",
                column: "AvailableThrowRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_ThrowRequest_AvailableThrowRequestId",
                table: "Players",
                column: "AvailableThrowRequestId",
                principalTable: "ThrowRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_ThrowRequest_AvailableThrowRequestId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "ThrowRequest");

            migrationBuilder.DropIndex(
                name: "IX_Players_AvailableThrowRequestId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AvailableThrowRequestId",
                table: "Players");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:throw_motive", "movement,item");
        }
    }
}
