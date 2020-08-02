using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTShopSolution.Data.Migrations
{
    public partial class AddProductImageTableFixPublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6402391-4220-4df2-948a-b17b13f0af65"),
                column: "ConcurrencyStamp",
                value: "73f934ab-3f9c-4256-8bda-ac4eafc781c7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("58fc3808-5242-4133-95fb-23781d0465ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e59b6bc-432f-4d0d-a0cf-355f949e0da6", "AQAAAAEAACcQAAAAEJhZp5WJKPqT7eTFZgXeRiVdIzJdd2MVBGtRyPKAH6KRHmOvh2u/ed0uVbJrOQq2YQ==" });

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
                value: new DateTime(2020, 8, 2, 9, 56, 15, 635, DateTimeKind.Local).AddTicks(6449));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
