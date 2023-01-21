using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisDatenbank.Migrations
{
    public partial class _333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d7d65dc2-3a24-42e4-9856-3787b4bcaca2", "d9d60b8d-10fe-456d-86f5-c4603a15264e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7d65dc2-3a24-42e4-9856-3787b4bcaca2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9d60b8d-10fe-456d-86f5-c4603a15264e");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Thesis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6724fa16-cf3c-4037-b745-b674113d59e1", "4db98a8c-f733-430d-b18e-da908100e7e0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activity", "ChairId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1f6b3d2a-76be-40c5-a659-6f8ff948abdb", 0, null, null, "65696923-f350-442a-80f3-f1b43370b8cb", null, false, null, null, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAEGub21g4YyoJYhn8sgtAc0n05E+IP6wHLec3HwwLkr//xWF+1uAe0Q2snDpj9IDNPA==", null, false, "a20c28dc-25a0-45ff-a9d0-12c3f382ed3a", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6724fa16-cf3c-4037-b745-b674113d59e1", "1f6b3d2a-76be-40c5-a659-6f8ff948abdb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6724fa16-cf3c-4037-b745-b674113d59e1", "1f6b3d2a-76be-40c5-a659-6f8ff948abdb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6724fa16-cf3c-4037-b745-b674113d59e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f6b3d2a-76be-40c5-a659-6f8ff948abdb");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7d65dc2-3a24-42e4-9856-3787b4bcaca2", "3871ca76-cc71-4ebc-a699-439f3d189fa7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activity", "ChairId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9d60b8d-10fe-456d-86f5-c4603a15264e", 0, null, null, "85eeff06-0aec-42a8-95f9-6ddd0ec0079a", null, false, null, null, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAEOcRpJ4TeUECPcCXbNw2e1GT++TFl5qFUz15n9HyoP8rVI7jtBE1CA/H4IRTn5ygBg==", null, false, "14ddc246-ba0c-4b19-ae03-a465c3fcea71", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7d65dc2-3a24-42e4-9856-3787b4bcaca2", "d9d60b8d-10fe-456d-86f5-c4603a15264e" });

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
