using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Specifications");

            migrationBuilder.RenameColumn(
                name: "Inventory",
                table: "Specifications",
                newName: "Seq");

            migrationBuilder.AddColumn<int>(
                name: "ProductDetailId",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "SpecificationReferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seq",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreateAt", "Inventory", "IsDelete", "ProductId", "SKU", "Seq", "UnitPrice", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(606), 10, false, 1, "Micky-Black-S", 1, 100m, null },
                    { 2, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(611), 10, false, 1, "Micky-Black-M", 2, 100m, null },
                    { 3, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(616), 10, false, 1, "Micky-Black-L", 1, 100m, null },
                    { 4, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(618), 10, false, 1, "Micky-Black-XL", 1, 100m, null },
                    { 5, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(621), 10, false, 1, "Micky-White-XL", 1, 100m, null },
                    { 6, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(630), 10, false, 1, "Micky-White-M", 1, 100m, null },
                    { 7, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(632), 10, false, 1, "Micky-Red-XS", 1, 100m, null },
                    { 8, new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(634), 10, false, 1, "Micky-Gray-S", 1, 100m, null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Description", "ProductName", "Seq" },
                values: new object[] { new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(561), "米奇潮T", "潮T", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Description", "ImagePath", "ProductName", "Seq" },
                values: new object[] { new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(565), "圍巾 DESC.", "https://picsum.photos/300/200/?random=2", "圍巾", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Description", "ImagePath", "ProductName", "Seq" },
                values: new object[] { new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(567), "蛋糕 DESC.", "https://picsum.photos/300/200/?random=3", "蛋糕", 0 });

            migrationBuilder.UpdateData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProductDetailId", "Seq", "SpecificationValue" },
                values: new object[] { 1, 0, "S" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProductDetailId", "Seq", "SpecificationValue" },
                values: new object[] { 2, 0, "M" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductDetailId", "Seq", "SpecificationReferenceId", "SpecificationValue" },
                values: new object[] { 3, 0, 1, "L" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductDetailId", "Seq", "SpecificationReferenceId", "SpecificationValue" },
                values: new object[] { 4, 0, 1, "XL" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductDetailId", "Seq", "SpecificationReferenceId", "SpecificationValue" },
                values: new object[] { 1, 0, 3, "黑色" });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CreateAt", "IsDelete", "ProductDetailId", "Seq", "SpecificationReferenceId", "SpecificationValue", "UpdateAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 0, 3, "黑色", null },
                    { 7, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 0, 3, "黑色", null },
                    { 8, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 0, 3, "黑色", null },
                    { 9, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, 0, 3, "白色", null },
                    { 10, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, 0, 3, "白色", null },
                    { 11, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, 0, 1, "M", null },
                    { 12, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, 0, 1, "XL", null },
                    { 13, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, 0, 3, "紅色", null },
                    { 14, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, 0, 1, "XS", null },
                    { 15, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, 0, 3, "灰色", null },
                    { 16, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, 0, 1, "S", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProductDetailId",
                table: "Specifications",
                column: "ProductDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_ProductDetails_ProductDetailId",
                table: "Specifications",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_ProductDetails_ProductDetailId",
                table: "Specifications");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_ProductDetailId",
                table: "Specifications");

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "SpecificationReferences");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "Coupons");

            migrationBuilder.RenameColumn(
                name: "Seq",
                table: "Specifications",
                newName: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Specifications",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Description", "ProductName" },
                values: new object[] { new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7000), "Product1 DESC.", "Product1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Description", "ImagePath", "ProductName" },
                values: new object[] { new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7004), "Product222 DESC.", "https://picsum.photos/300/200/?random=1", "Product222" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Description", "ImagePath", "ProductName" },
                values: new object[] { new DateTime(2023, 8, 30, 8, 55, 14, 777, DateTimeKind.Utc).AddTicks(7006), "Product000 DESC.", "https://picsum.photos/300/200/?random=1", "Product000" });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Inventory", "SKU", "SpecificationValue", "UnitPrice" },
                values: new object[] { 10, "Product1-XL", "XL", 10m });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Inventory", "SKU", "SpecificationValue", "UnitPrice" },
                values: new object[] { 10, "Product1-S", "S", 11m });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Inventory", "SKU", "SpecificationReferenceId", "SpecificationValue", "UnitPrice" },
                values: new object[] { 10, "Product222-Black", 3, "黑色", 15m });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Inventory", "SKU", "SpecificationReferenceId", "SpecificationValue", "UnitPrice" },
                values: new object[] { 15, "Product222-White", 3, "白色", 13m });

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Inventory", "SKU", "SpecificationReferenceId", "SpecificationValue", "UnitPrice" },
                values: new object[] { 100, "Product000", 2, "單一規格", 1.5m });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_ProductId",
                table: "ProductSpecifications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_SpecificationId",
                table: "ProductSpecifications",
                column: "SpecificationId");
        }
    }
}
