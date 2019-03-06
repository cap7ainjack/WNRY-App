using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WNRY.Migrations.Migrations
{
    public partial class AddressForeginKeyRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Addresses",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses",
                newName: "IX_Addresses_IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_IdentityId",
                table: "Addresses",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_IdentityId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Addresses",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_IdentityId",
                table: "Addresses",
                newName: "IX_Addresses_UserId1");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId1",
                table: "Addresses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
