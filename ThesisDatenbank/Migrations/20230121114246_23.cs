using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisDatenbank.Migrations
{
    public partial class _23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53de138c-e4a5-43b1-951f-b676890cc40b", "32ed985d-9de8-4cce-8236-7abe5bb64ed3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53de138c-e4a5-43b1-951f-b676890cc40b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32ed985d-9de8-4cce-8236-7abe5bb64ed3");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "53de138c-e4a5-43b1-951f-b676890cc40b", "b364674f-ff44-417f-8a9a-5754510d598d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activity", "ChairId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32ed985d-9de8-4cce-8236-7abe5bb64ed3", 0, null, null, "9164e72c-f95a-4557-8fe1-0e1dfe2d6178", null, false, null, null, false, null, null, "ADMIN@THESIS.DE", "AQAAAAEAACcQAAAAENiyX1UK3qjC+LIovwaMesRdxO4nzCayvkUXe7wtt0Kznm9GKiUKDq8gOPulrI828A==", null, false, "f8a6028a-31e7-47ea-8240-0280b763af39", false, "admin@thesis.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53de138c-e4a5-43b1-951f-b676890cc40b", "32ed985d-9de8-4cce-8236-7abe5bb64ed3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis",
                column: "SupervisorId",
                principalTable: "Supervisor",
                principalColumn: "Id");
        }
    }
}
