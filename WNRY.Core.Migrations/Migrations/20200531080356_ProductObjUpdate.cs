using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WNRY.Migrations.Migrations
{
    public partial class ProductObjUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Products",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BottleKind", "Description", "DisplayName", "Kind", "PhotoUrl", "Price", "Size", "WineColor" },
                values: new object[,]
                {
                    { new Guid("c51e8ce1-c6cc-4f08-86bd-e5016efa00bf"), 1, "Description here...", "Merlot", 1, "https://i.ibb.co/ckmdNgN/5.jpg", 11m, 0.69999999999999996, 1 },
                    { new Guid("fbdeb80e-8348-4233-99b7-0c79780398aa"), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Cabernet Sauvignon", 2, "https://i.ibb.co/1bdMmvp/cabernet-resized.jpg", 11m, 0.69999999999999996, 1 },
                    { new Guid("32e90a4a-9955-42f6-b172-12296cdee653"), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", "Rose", 9, "https://i.ibb.co/gghGqWM/rose-resized.jpg", 9m, 0.69999999999999996, 3 },
                    { new Guid("ff8ffe32-2e84-4c4f-9205-49794fbdf5b7"), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "Chardonnay", 5, "https://i.ibb.co/sbgkKjH/Chardonnay-resized.jpg", 9m, 0.69999999999999996, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32e90a4a-9955-42f6-b172-12296cdee653"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c51e8ce1-c6cc-4f08-86bd-e5016efa00bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fbdeb80e-8348-4233-99b7-0c79780398aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff8ffe32-2e84-4c4f-9205-49794fbdf5b7"));

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Products");
        }
    }
}
