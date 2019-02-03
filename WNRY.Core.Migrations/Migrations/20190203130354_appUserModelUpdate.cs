using Microsoft.EntityFrameworkCore.Migrations;

namespace WNRY.Migrations.Migrations
{
    public partial class appUserModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "ContactsDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactsDetails_IdentityId",
                table: "ContactsDetails",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactsDetails_AspNetUsers_IdentityId",
                table: "ContactsDetails",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactsDetails_AspNetUsers_IdentityId",
                table: "ContactsDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactsDetails_IdentityId",
                table: "ContactsDetails");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "ContactsDetails");
        }
    }
}
