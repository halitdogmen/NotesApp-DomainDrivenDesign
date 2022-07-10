using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesApp.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admins_accounts_Id",
                        column: x => x.Id,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "standartusers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_standartusers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_standartusers_accounts_Id",
                        column: x => x.Id,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "imagenotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenotes_notes_Id",
                        column: x => x.Id,
                        principalTable: "notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => new { x.NoteId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tag_notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "textnotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textnotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_textnotes_notes_Id",
                        column: x => x.Id,
                        principalTable: "notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "PasswordHash", "PasswordSalt", "UpdateAt", "Email" },
                values: new object[] { new Guid("c9068738-d4fa-4bac-86b3-2c4dbbe64258"), new DateTime(2022, 7, 10, 10, 19, 44, 408, DateTimeKind.Utc).AddTicks(6483), null, false, new byte[] { 247, 179, 50, 74, 252, 211, 169, 154, 221, 148, 230, 153, 67, 53, 150, 185, 94, 44, 117, 121, 119, 137, 23, 188, 31, 146, 196, 220, 129, 55, 160, 1, 27, 68, 24, 109, 246, 86, 38, 167, 242, 111, 63, 36, 241, 7, 242, 198, 165, 252, 111, 31, 36, 21, 77, 242, 105, 82, 99, 64, 71, 206, 228, 69 }, new byte[] { 245, 152, 9, 75, 101, 250, 218, 102, 213, 142, 187, 225, 186, 186, 10, 117, 234, 189, 180, 212, 214, 98, 169, 51, 225, 220, 95, 110, 2, 101, 226, 72, 183, 233, 209, 161, 157, 195, 27, 25, 67, 76, 55, 212, 106, 181, 220, 146, 182, 60, 169, 251, 83, 67, 249, 5, 30, 244, 168, 64, 30, 54, 224, 58, 165, 209, 143, 38, 101, 255, 216, 166, 146, 159, 40, 156, 63, 200, 49, 115, 232, 224, 104, 62, 122, 76, 6, 231, 96, 174, 155, 10, 112, 142, 89, 214, 115, 189, 151, 109, 63, 184, 165, 6, 227, 72, 3, 68, 44, 74, 205, 92, 32, 77, 137, 252, 67, 17, 41, 245, 60, 211, 233, 229, 148, 131, 34, 74 }, null, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "NickName" },
                values: new object[] { new Guid("c9068738-d4fa-4bac-86b3-2c4dbbe64258"), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_Email",
                table: "accounts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_notes_AccountId",
                table: "notes",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "imagenotes");

            migrationBuilder.DropTable(
                name: "standartusers");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "textnotes");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "notes");
        }
    }
}
