using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WNRY.Migrations.Migrations
{
    public partial class ProductsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32e90a4a-9955-42f6-b172-12296cdee653"),
                column: "DisplayName",
                value: "Розе");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c51e8ce1-c6cc-4f08-86bd-e5016efa00bf"),
                column: "DisplayName",
                value: "Мерло");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fbdeb80e-8348-4233-99b7-0c79780398aa"),
                column: "DisplayName",
                value: "Каберне Совиньон");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff8ffe32-2e84-4c4f-9205-49794fbdf5b7"),
                column: "DisplayName",
                value: "Шардоне");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32e90a4a-9955-42f6-b172-12296cdee653"),
                column: "DisplayName",
                value: "Rose");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c51e8ce1-c6cc-4f08-86bd-e5016efa00bf"),
                column: "DisplayName",
                value: "Merlot");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fbdeb80e-8348-4233-99b7-0c79780398aa"),
                column: "DisplayName",
                value: "Cabernet Sauvignon");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff8ffe32-2e84-4c4f-9205-49794fbdf5b7"),
                column: "DisplayName",
                value: "Chardonnay");
        }
    }
}
