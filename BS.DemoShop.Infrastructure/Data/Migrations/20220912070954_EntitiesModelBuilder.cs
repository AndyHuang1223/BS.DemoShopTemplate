using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.DemoShop.Infrastructure.Data.Migrations
{
    public partial class EntitiesModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 12, 7, 9, 53, 719, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 12, 7, 9, 53, 720, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 12, 7, 9, 53, 720, DateTimeKind.Unspecified).AddTicks(3200), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 730, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 728, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 728, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 12, 7, 9, 53, 728, DateTimeKind.Utc).AddTicks(2620));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 10, 9, 24, 18, 881, DateTimeKind.Unspecified).AddTicks(4521), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 10, 9, 24, 18, 882, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 10, 9, 24, 18, 882, DateTimeKind.Unspecified).AddTicks(2417), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 888, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 887, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 887, DateTimeKind.Utc).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 10, 9, 24, 18, 887, DateTimeKind.Utc).AddTicks(5533));
        }
    }
}
