using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTShopSolution.Data.Migrations
{
    public partial class AddProductImageTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6402391-4220-4df2-948a-b17b13f0af65"),
                column: "ConcurrencyStamp",
                value: "a0396c2d-1363-40bd-bd27-d0ed2e2949a3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("58fc3808-5242-4133-95fb-23781d0465ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd7be4c2-64d0-40db-9dd5-c4bd84d0dc79", "AQAAAAEAACcQAAAAELF3pF+ajJ0gJmSSst+JMhbVd1b5LvMU6qcMc9K9dkBirLIf7lS/S6tvgNczKBcK4g==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 8, 2, 8, 55, 6, 583, DateTimeKind.Local).AddTicks(2163));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6402391-4220-4df2-948a-b17b13f0af65"),
                column: "ConcurrencyStamp",
                value: "7c8780d5-2824-40b8-bee6-b484398ac93e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("58fc3808-5242-4133-95fb-23781d0465ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a282b7e8-4b7e-4fb4-9f1e-28c012b663e7", "AQAAAAEAACcQAAAAEDAxvdzcdizBChxzoSWcwI5eimMapjf5F55wzj5ySpXU5mR5DDBRVKZO5+55PY6+hw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 8, 2, 8, 49, 14, 429, DateTimeKind.Local).AddTicks(4294));
        }
    }
}
