using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSpecRef_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Seq",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 45, 7, 178, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "SpecificationReferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Seq",
                value: 0);
        }
    }
}
