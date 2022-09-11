using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.DemoShop.Infrastructure.Data.Migrations
{
    public partial class ModifyUserRoleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleType",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 15, 39, 20, 189, DateTimeKind.Unspecified).AddTicks(1751), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 15, 39, 20, 189, DateTimeKind.Unspecified).AddTicks(9520), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 15, 39, 20, 189, DateTimeKind.Unspecified).AddTicks(9587), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 196, DateTimeKind.Utc).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 195, DateTimeKind.Utc).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 195, DateTimeKind.Utc).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 15, 39, 20, 195, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "NormalUser");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "RoleType" },
                values: new object[,]
                {
                    { 2, "Administrator", 1 },
                    { 3, "Developer", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Email", "Name", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 11, 15, 39, 20, 345, DateTimeKind.Unspecified).AddTicks(7694), new TimeSpan(0, 0, 0, 0, 0)), "AdminUser@gmail.com", "AdminUser", "8095B76E4B6D46F529D65C8E75936C8D3BD689189B68CCA59826783031B64F79" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "Gender", "Name", "Password", "UpdatedTime" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 9, 11, 15, 39, 20, 346, DateTimeKind.Unspecified).AddTicks(1659), new TimeSpan(0, 0, 0, 0, 0)), "Developer@gmail.com", 0, "Developer", "3FB7B39416F1D067268747FC214494D759D2609F863ACE1A8A76705618D5C80B", null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 3, 2, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 4, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 7, 50, 4, 42, DateTimeKind.Unspecified).AddTicks(8451), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 7, 50, 4, 43, DateTimeKind.Unspecified).AddTicks(6768), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 7, 50, 4, 43, DateTimeKind.Unspecified).AddTicks(6852), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 48, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 50, 4, 49, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Normal");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Email", "Name", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 9, 11, 7, 50, 4, 201, DateTimeKind.Unspecified).AddTicks(4313), new TimeSpan(0, 0, 0, 0, 0)), "DefaultUser@gmail.com", "DefaultUser", "28EFB68DCBA507ECD182BEAD31E4E2D159B0F9185861D1EBFE60A12DFB310300" });
        }
    }
}
