using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_TodoItems_and_seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "CreateAt", "Description", "IsDelete", "IsDone", "Seq", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780), "TodoItem 1", false, false, 0, null },
                    { 2, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780), "TodoItem 2", false, false, 0, null },
                    { 3, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780), "TodoItem 3", false, false, 0, null },
                    { 4, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2780), "TodoItem 4", false, false, 0, null },
                    { 5, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790), "TodoItem 5", false, false, 0, null },
                    { 6, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790), "TodoItem 6", false, false, 0, null },
                    { 7, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790), "TodoItem 7", false, false, 0, null },
                    { 8, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790), "TodoItem 8", false, false, 0, null },
                    { 9, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790), "TodoItem 9", false, false, 0, null },
                    { 10, new DateTime(2024, 2, 26, 3, 56, 44, 472, DateTimeKind.Utc).AddTicks(2790), "TodoItem 10", false, false, 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

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

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 9, 19, 30, 676, DateTimeKind.Utc).AddTicks(8979));

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
        }
    }
}
