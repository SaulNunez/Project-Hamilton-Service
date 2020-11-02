using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHamiltonService.Migrations
{
    public partial class AgregaInfoDeItemEnThrowRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThrowRequest_Players_PlayerId",
                table: "ThrowRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThrowRequest",
                table: "ThrowRequest");

            migrationBuilder.RenameTable(
                name: "ThrowRequest",
                newName: "ThrowRequests");

            migrationBuilder.RenameIndex(
                name: "IX_ThrowRequest_PlayerId",
                table: "ThrowRequests",
                newName: "IX_ThrowRequests_PlayerId");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "ThrowRequests",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThrowRequests",
                table: "ThrowRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThrowRequests_ItemId",
                table: "ThrowRequests",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThrowRequests_Items_ItemId",
                table: "ThrowRequests",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThrowRequests_Players_PlayerId",
                table: "ThrowRequests",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThrowRequests_Items_ItemId",
                table: "ThrowRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ThrowRequests_Players_PlayerId",
                table: "ThrowRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThrowRequests",
                table: "ThrowRequests");

            migrationBuilder.DropIndex(
                name: "IX_ThrowRequests_ItemId",
                table: "ThrowRequests");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ThrowRequests");

            migrationBuilder.RenameTable(
                name: "ThrowRequests",
                newName: "ThrowRequest");

            migrationBuilder.RenameIndex(
                name: "IX_ThrowRequests_PlayerId",
                table: "ThrowRequest",
                newName: "IX_ThrowRequest_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThrowRequest",
                table: "ThrowRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThrowRequest_Players_PlayerId",
                table: "ThrowRequest",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
