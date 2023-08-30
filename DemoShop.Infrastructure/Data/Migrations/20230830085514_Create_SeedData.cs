using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateAt", "Description", "ImagePath", "IsDelete", "IsOnTheMarket", "ProductName", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7000), "Product1 DESC.", "https://picsum.photos/300/200/?random=1", false, true, "Product1", null },
                    { 2, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7004), "Product222 DESC.", "https://picsum.photos/300/200/?random=1", false, true, "Product222", null },
                    { 3, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7006), "Product000 DESC.", "https://picsum.photos/300/200/?random=1", false, true, "Product000", null }
                });

            migrationBuilder.InsertData(
                table: "SpecificationReferences",
                columns: new[] { "Id", "CreateAt", "IsDelete", "SpecificationName", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "尺寸", null },
                    { 2, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "規格", null },
                    { 3, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "顏色", null }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CreateAt", "Inventory", "IsDelete", "SKU", "SpecificationReferenceId", "SpecificationValue", "UnitPrice", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false, "Product1-XL", 1, "XL", 10m, null },
                    { 2, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false, "Product1-S", 1, "S", 11m, null },
                    { 3, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false, "Product222-Black", 3, "黑色", 15m, null },
                    { 4, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, false, "Product222-White", 3, "白色", 13m, null },
                    { 5, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, false, "Product000", 2, "單一規格", 1.5m, null }
                });

            migrationBuilder.InsertData(
                table: "ProductSpecifications",
                columns: new[] { "Id", "CreateAt", "IsDelete", "ProductId", "SpecificationId", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7030), false, 1, 1, null },
                    { 2, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7033), false, 1, 2, null },
                    { 3, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7035), false, 2, 3, null },
                    { 4, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7037), false, 2, 4, null },
                    { 5, new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7039), false, 3, 5, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSpecifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductSpecifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductSpecifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductSpecifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductSpecifications",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
