using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.DemoShop.Infrastructure.Data.Migrations
{
    public partial class UserModuleEntitiesAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 7, 38, 19, 397, DateTimeKind.Unspecified).AddTicks(3923), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 7, 38, 19, 398, DateTimeKind.Unspecified).AddTicks(2227), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTimeOffset(new DateTime(2022, 9, 11, 7, 38, 19, 398, DateTimeKind.Unspecified).AddTicks(2296), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 404, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 403, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 403, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2022, 9, 11, 7, 38, 19, 403, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Normal" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "Gender", "Name", "Password", "UpdatedTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 9, 11, 7, 38, 19, 557, DateTimeKind.Unspecified).AddTicks(3941), new TimeSpan(0, 0, 0, 0, 0)), "DefaultUser@gmail.com", 0, "DefaultUser", "28EFB68DCBA507ECD182BEAD31E4E2D159B0F9185861D1EBFE60A12DFB310300", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

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
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

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
