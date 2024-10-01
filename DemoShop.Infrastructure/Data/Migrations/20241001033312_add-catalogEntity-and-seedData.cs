using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcatalogEntityandseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCatalogId = table.Column<int>(type: "int", nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Catalog_ParentCatalogId",
                        column: x => x.ParentCatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CreateAt", "IsDelete", "Name", "ParentCatalogId", "Seq", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 3, 33, 12, 344, DateTimeKind.Utc).AddTicks(7890), false, "Catalog 1", null, 0, null },
                    { 2, new DateTime(2024, 10, 1, 3, 33, 12, 344, DateTimeKind.Utc).AddTicks(7890), false, "Catalog 2", null, 0, null },
                    { 3, new DateTime(2024, 10, 1, 3, 33, 12, 344, DateTimeKind.Utc).AddTicks(7890), false, "Catalog 3", null, 0, null }
                });

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 10, 1, 3, 33, 12, 343, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CreateAt", "IsDelete", "Name", "ParentCatalogId", "Seq", "UpdateAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 10, 1, 3, 33, 12, 344, DateTimeKind.Utc).AddTicks(7890), false, "Catalog 1-1", 1, 0, null },
                    { 5, new DateTime(2024, 10, 1, 3, 33, 12, 344, DateTimeKind.Utc).AddTicks(7900), false, "Catalog 1-1-1", 4, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ParentCatalogId",
                table: "Catalog",
                column: "ParentCatalogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790));
        }
    }
}
