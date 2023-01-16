using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisDatenbank.Migrations
{
    public partial class MC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b931eb1a-9a89-4a72-8cff-a5bddb37f429", "3ee89c6e-351a-42f7-b9bf-4507bd5c03e1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d5867a9-24fa-4ac6-848e-b978d501a782", 0, "fb82087e-427c-458a-b234-b1fa7e582381", null, false, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAEGHhpItCsQNG+VtpbbG8Elj9AwMlZo+XAZai59C/C0ve63QpE4VjBSRN002u0EZ7KA==", null, false, "0dfab66b-b9f7-4b95-8751-e2cadc17f71f", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b931eb1a-9a89-4a72-8cff-a5bddb37f429", "2d5867a9-24fa-4ac6-848e-b978d501a782" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b931eb1a-9a89-4a72-8cff-a5bddb37f429", "2d5867a9-24fa-4ac6-848e-b978d501a782" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b931eb1a-9a89-4a72-8cff-a5bddb37f429");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5867a9-24fa-4ac6-848e-b978d501a782");

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
    }
}
