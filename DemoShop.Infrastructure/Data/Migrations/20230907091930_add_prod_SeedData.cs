using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_prod_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8973));

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreateAt", "Inventory", "IsDelete", "ProductId", "SKU", "Seq", "UnitPrice", "UpdateAt" },
                values: new object[,]
                {
                    { 9, new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8975), 5, false, 2, "Scarf", 0, 50m, null },
                    { 10, new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8978), 15, false, 3, "Cake-Banana", 0, 599m, null },
                    { 11, new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8979), 20, false, 3, "Cake-Chocolate", 1, 599m, null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8919));

            migrationBuilder.InsertData(
                table: "SpecificationReferences",
                columns: new[] { "Id", "CreateAt", "IsDelete", "Seq", "SpecificationName", "UpdateAt" },
                values: new object[] { 4, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, "口味", null });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CreateAt", "IsDelete", "ProductDetailId", "Seq", "SpecificationReferenceId", "SpecificationValue", "UpdateAt" },
                values: new object[,]
                {
                    { 17, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, 0, 2, "單一規格", null },
                    { 18, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, 1, 4, "香蕉", null },
                    { 19, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 11, 0, 4, "巧克力", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 48, 26, 898, DateTimeKind.Utc).AddTicks(8541));
        }
    }
}
