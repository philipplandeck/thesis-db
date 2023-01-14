using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisDatenbank.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThesisThemen",
                table: "ThesisThemen");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e96393e7-ccd0-4a52-b714-a44f07adfb52", "433a01c6-eac1-4e47-9b44-35229a87c8c3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e96393e7-ccd0-4a52-b714-a44f07adfb52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "433a01c6-eac1-4e47-9b44-35229a87c8c3");

            migrationBuilder.RenameTable(
                name: "ThesisThemen",
                newName: "Thesis");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Thesis",
                newName: "Weaknesses");

            migrationBuilder.AddColumn<bool>(
                name: "Bachelor",
                table: "Thesis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ChairId",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContentVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContentWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Evaluation",
                table: "Thesis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Filing",
                table: "Thesis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Thesis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LayoutVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LayoutWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiteratureVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiteratureWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Master",
                table: "Thesis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NoveltyVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoveltyWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registration",
                table: "Thesis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RichnessVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RichnessWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Strengths",
                table: "Thesis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StructureVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StructureWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentEMail",
                table: "Thesis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Thesis",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Thesis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudentProgramId",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StyleVal",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StyleWt",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Thesis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Thesis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Thesis",
                table: "Thesis",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Chair",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chair", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_ChairId",
                table: "Thesis",
                column: "ChairId");

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_StudentProgramId",
                table: "Thesis",
                column: "StudentProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_SupervisorId",
                table: "Thesis",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Chair_ChairId",
                table: "Thesis",
                column: "ChairId",
                principalTable: "Chair",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Program_StudentProgramId",
                table: "Thesis",
                column: "StudentProgramId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Thesis_Chair_ChairId",
                table: "Thesis");

            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Program_StudentProgramId",
                table: "Thesis");

            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Supervisor_SupervisorId",
                table: "Thesis");

            migrationBuilder.DropTable(
                name: "Chair");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Thesis",
                table: "Thesis");

            migrationBuilder.DropIndex(
                name: "IX_Thesis_ChairId",
                table: "Thesis");

            migrationBuilder.DropIndex(
                name: "IX_Thesis_StudentProgramId",
                table: "Thesis");

            migrationBuilder.DropIndex(
                name: "IX_Thesis_SupervisorId",
                table: "Thesis");

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

            migrationBuilder.DropColumn(
                name: "Bachelor",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "ChairId",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "ContentVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "ContentWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "DifficultyVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "DifficultyWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Filing",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "LayoutVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "LayoutWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "LiteratureVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "LiteratureWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Master",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "NoveltyVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "NoveltyWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Registration",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "RichnessVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "RichnessWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Strengths",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StructureVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StructureWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StudentEMail",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StudentProgramId",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StyleVal",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "StyleWt",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Thesis");

            migrationBuilder.RenameTable(
                name: "Thesis",
                newName: "ThesisThemen");

            migrationBuilder.RenameColumn(
                name: "Weaknesses",
                table: "ThesisThemen",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThesisThemen",
                table: "ThesisThemen",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e96393e7-ccd0-4a52-b714-a44f07adfb52", "17efd360-8282-42a4-a9ff-27e598360c26", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "433a01c6-eac1-4e47-9b44-35229a87c8c3", 0, "b71c657b-0cf4-46ea-8117-4a0daf03423c", null, false, false, null, null, "ADMIN@ABC.COM", "AQAAAAEAACcQAAAAEMxGNI2AMHbCMe5373973pp5OVm1nSn7ERtQFjEK4AbhSDYG86o8v5ZFCUhhcjYpfA==", null, false, "a46df28e-94e4-42f9-95c8-6016d9611d38", false, "admin@abc.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e96393e7-ccd0-4a52-b714-a44f07adfb52", "433a01c6-eac1-4e47-9b44-35229a87c8c3" });
        }
    }
}
