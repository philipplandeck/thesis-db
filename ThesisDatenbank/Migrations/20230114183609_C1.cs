using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisDatenbank.Migrations
{
    public partial class C1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64ecc37a-ab98-4e5e-bccb-395da980d596", "f5124f90-d3fd-476a-ba4e-47f9751be7a8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64ecc37a-ab98-4e5e-bccb-395da980d596");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5124f90-d3fd-476a-ba4e-47f9751be7a8");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Chair",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ef44e64-618e-45b9-858d-4a198829e235", "d09f9ad5-c062-4694-ad55-49727ad89228", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9790081-2486-46bb-a978-b312afa58a9e", 0, "475d2e25-639e-479b-b189-aa059e816e95", null, false, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAECBMucUYc1BKQE/xVcafJNVeF1PtRksrnVcUaH89NhkMT9anUrgz9g06QxTMi9bAgA==", null, false, "5366551e-bef0-4a67-883d-513ec12bde5f", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2ef44e64-618e-45b9-858d-4a198829e235", "d9790081-2486-46bb-a978-b312afa58a9e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ef44e64-618e-45b9-858d-4a198829e235", "d9790081-2486-46bb-a978-b312afa58a9e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ef44e64-618e-45b9-858d-4a198829e235");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9790081-2486-46bb-a978-b312afa58a9e");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Chair",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64ecc37a-ab98-4e5e-bccb-395da980d596", "a95d196a-b8c3-49db-a840-6152573503e4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5124f90-d3fd-476a-ba4e-47f9751be7a8", 0, "d50cfd05-2937-43ea-919a-1e69c8138e05", null, false, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAEO89LlONFSeCv4PP9384DlJ5nRgKug+nnEPD/0zL1DZXRKvEiyUkq8juHHwCN/rMwg==", null, false, "eec2ae3b-f3b3-4468-8eac-fada17c4b294", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "64ecc37a-ab98-4e5e-bccb-395da980d596", "f5124f90-d3fd-476a-ba4e-47f9751be7a8" });
        }
    }
}
