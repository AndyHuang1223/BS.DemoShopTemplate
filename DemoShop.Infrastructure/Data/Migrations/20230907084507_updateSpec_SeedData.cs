using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSpec_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Seq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Seq",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Seq",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Seq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 10,
                column: "Seq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 12,
                column: "Seq",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 13,
                column: "Seq",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 15,
                column: "Seq",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2023, 9, 7, 8, 34, 27, 217, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 10,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 12,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 13,
                column: "Seq",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 15,
                column: "Seq",
                value: 0);
        }
    }
}
