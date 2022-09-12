using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.DemoShop.Infrastructure.Data.Migrations
{
    public partial class initCreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnTheMarket = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 12, 9, 47, 12, 966, DateTimeKind.Unspecified).AddTicks(5580), new TimeSpan(0, 0, 0, 0, 0)), "預設分類1", 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 12, 9, 47, 12, 967, DateTimeKind.Unspecified).AddTicks(5400), new TimeSpan(0, 0, 0, 0, 0)), "預設分類2", 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 9, 12, 9, 47, 12, 967, DateTimeKind.Unspecified).AddTicks(5470), new TimeSpan(0, 0, 0, 0, 0)), "預設分類3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "RoleType" },
                values: new object[,]
                {
                    { 1, "NormalUser", 0 },
                    { 2, "Administrator", 1 },
                    { 3, "Developer", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "Gender", "Name", "Password", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 12, 9, 47, 12, 981, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 0, 0, 0, 0)), "AdminUser@gmail.com", 0, "AdminUser", "8095B76E4B6D46F529D65C8E75936C8D3BD689189B68CCA59826783031B64F79", null },
                    { 2, new DateTimeOffset(new DateTime(2022, 9, 12, 9, 47, 12, 981, DateTimeKind.Unspecified).AddTicks(3190), new TimeSpan(0, 0, 0, 0, 0)), "Developer@gmail.com", 0, "Developer", "3FB7B39416F1D067268747FC214494D759D2609F863ACE1A8A76705618D5C80B", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Description", "ImgPath", "IsOnTheMarket", "Name", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 12, 9, 47, 12, 974, DateTimeKind.Utc).AddTicks(8140), null, "https://picsum.photos/300/200/?random=1", true, "種子商品1", null },
                    { 2, 2, new DateTime(2022, 9, 12, 9, 47, 12, 974, DateTimeKind.Utc).AddTicks(8600), null, "https://picsum.photos/300/200/?random=2", false, "種子商品2", null },
                    { 3, 3, new DateTime(2022, 9, 12, 9, 47, 12, 974, DateTimeKind.Utc).AddTicks(8610), null, "https://picsum.photos/300/200/?random=3", true, "種子商品3", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 3, 2, 1 },
                    { 2, 1, 2 },
                    { 4, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreatedTime", "Inventory", "Name", "ProductId", "UnitPrice", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(8680), 100, "種子規格1", 1, 100m, null },
                    { 2, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(9140), 10, "種子規格2", 1, 100m, null },
                    { 3, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(9140), 8, "種子規格3", 1, 100m, null },
                    { 4, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(9150), 18, "種子規格4", 2, 100m, null },
                    { 5, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(9150), 0, "種子規格4", 3, 100m, null },
                    { 6, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(9160), 120, "種子規格4", 3, 100m, null },
                    { 7, new DateTime(2022, 9, 12, 9, 47, 12, 976, DateTimeKind.Utc).AddTicks(9160), 20, "種子規格4", 3, 100m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
