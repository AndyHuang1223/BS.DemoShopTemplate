using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.DemoShop.Infrastructure.Data.Migrations
{
    public partial class addToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 319, DateTimeKind.Unspecified).AddTicks(7260), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 319, DateTimeKind.Unspecified).AddTicks(8910), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 319, DateTimeKind.Unspecified).AddTicks(8920), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(3980), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(6060), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(6070), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(6090), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(6120), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 324, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 322, DateTimeKind.Unspecified).AddTicks(4130), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 322, DateTimeKind.Unspecified).AddTicks(6820), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 322, DateTimeKind.Unspecified).AddTicks(6960), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 333, DateTimeKind.Unspecified).AddTicks(3640), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 4, 12, 14, 334, DateTimeKind.Unspecified).AddTicks(90), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockTokens");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 428, DateTimeKind.Unspecified).AddTicks(6188), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 428, DateTimeKind.Unspecified).AddTicks(6490), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 428, DateTimeKind.Unspecified).AddTicks(6493), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2449), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2647), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2649), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2653), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2657), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 430, DateTimeKind.Unspecified).AddTicks(2659), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 429, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 429, DateTimeKind.Unspecified).AddTicks(7280), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 429, DateTimeKind.Unspecified).AddTicks(7282), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 580, DateTimeKind.Unspecified).AddTicks(3681), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 19, 17, 22, 2, 580, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
