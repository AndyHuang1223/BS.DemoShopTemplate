using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.DemoShop.Infrastructure.Data.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnTheMarket",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedTime", "Description", "ImgPath", "IsOnTheMarket", "Name", "UpdatedTime" },
                values: new object[] { 1, new DateTime(2022, 9, 9, 15, 0, 58, 131, DateTimeKind.Utc).AddTicks(482), null, "https://picsum.photos/300/200/?random=1", true, "種子商品1", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedTime", "Description", "ImgPath", "IsOnTheMarket", "Name", "UpdatedTime" },
                values: new object[] { 2, new DateTime(2022, 9, 9, 15, 0, 58, 131, DateTimeKind.Utc).AddTicks(9137), null, "https://picsum.photos/300/200/?random=2", false, "種子商品2", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedTime", "Description", "ImgPath", "IsOnTheMarket", "Name", "UpdatedTime" },
                values: new object[] { 3, new DateTime(2022, 9, 9, 15, 0, 58, 131, DateTimeKind.Utc).AddTicks(9203), null, "https://picsum.photos/300/200/?random=3", true, "種子商品3", null });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreatedTime", "Inventory", "Name", "ProductId", "UnitPrice", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(8957), 100, "種子規格1", 1, 100m, null },
                    { 2, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(9257), 10, "種子規格2", 1, 100m, null },
                    { 3, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(9276), 8, "種子規格3", 1, 100m, null },
                    { 4, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(9298), 18, "種子規格4", 2, 100m, null },
                    { 5, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(9315), 0, "種子規格4", 3, 100m, null },
                    { 6, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(9333), 120, "種子規格4", 3, 100m, null },
                    { 7, new DateTime(2022, 9, 9, 15, 0, 58, 134, DateTimeKind.Utc).AddTicks(9349), 20, "種子規格4", 3, 100m, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IsOnTheMarket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "ProductDetails");
        }
    }
}
