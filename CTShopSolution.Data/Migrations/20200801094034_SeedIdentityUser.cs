using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("a6402391-4220-4df2-948a-b17b13f0af65"), "128daf44-80be-4c28-a0ba-0867bf2cf431", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("58fc3808-5242-4133-95fb-23781d0465ef"), new Guid("a6402391-4220-4df2-948a-b17b13f0af65") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("58fc3808-5242-4133-95fb-23781d0465ef"), 0, "4d6438a2-9fc6-41a9-8547-43bc26876c1b", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "thanhyen0710@gmail.com", true, "Yen", "Dang", false, null, "thanhyen0710@gmail.com", "admin", "AQAAAAEAACcQAAAAEF+Clw6pAyFth++0ZFd62dw9tSzf+KNItpupImdBThgeg25lZjl5TPdoqmQliCksAQ==", null, false, "", false, "admin" });

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
                value: new DateTime(2020, 8, 1, 16, 40, 34, 210, DateTimeKind.Local).AddTicks(27));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6402391-4220-4df2-948a-b17b13f0af65"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("58fc3808-5242-4133-95fb-23781d0465ef"), new Guid("a6402391-4220-4df2-948a-b17b13f0af65") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("58fc3808-5242-4133-95fb-23781d0465ef"));

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
                value: new DateTime(2020, 8, 1, 16, 29, 46, 372, DateTimeKind.Local).AddTicks(808));
        }
    }
}
