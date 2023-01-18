using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisDatenbank.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "47c267e0-3cf0-45f0-935d-374a69a1f273", "f45ec871-047e-4d86-8141-12a43a1270ca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47c267e0-3cf0-45f0-935d-374a69a1f273");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f45ec871-047e-4d86-8141-12a43a1270ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "059f8e18-5ce5-4125-84f0-72c5a6e59be7", "e9ceffeb-1865-427c-9cfe-7873d2eb7cd9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activity", "ChairId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a40a8cd-d4af-4671-8be5-7c6ddb518716", 0, null, null, "09e5afcc-3002-4d8e-8611-caab6a735d32", null, false, null, null, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAEG05VXjWkkYiGNFm9gXjYoBKE/5loU23+sMmQgBwwEmq3QkMSG/V06d4a//B1zFMLA==", null, false, "98359a83-c1ce-4a5a-9a6b-3c11f9661085", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "059f8e18-5ce5-4125-84f0-72c5a6e59be7", "1a40a8cd-d4af-4671-8be5-7c6ddb518716" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "059f8e18-5ce5-4125-84f0-72c5a6e59be7", "1a40a8cd-d4af-4671-8be5-7c6ddb518716" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "059f8e18-5ce5-4125-84f0-72c5a6e59be7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a40a8cd-d4af-4671-8be5-7c6ddb518716");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47c267e0-3cf0-45f0-935d-374a69a1f273", "31f0a879-d1e4-489f-a8cc-c269b2abad49", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activity", "ChairId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f45ec871-047e-4d86-8141-12a43a1270ca", 0, null, null, "2d86cdb9-f4f9-41d0-94eb-ac0ade5aa036", null, false, null, null, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAENAw89t51atLVwpgjNVCtCa6yId/9QLpDHsu50IJHvmdJlOKntoNnmMe4MJoEOJqDg==", null, false, "04825c56-040b-439f-a653-411fbdf00aec", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "47c267e0-3cf0-45f0-935d-374a69a1f273", "f45ec871-047e-4d86-8141-12a43a1270ca" });
        }
    }
}
