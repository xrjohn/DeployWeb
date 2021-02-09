using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeployWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payloads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ref = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Action = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Commits = table.Column<string>(type: "TEXT", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayloadUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PayloadId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayloadUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayloadUsers_Payloads_PayloadId",
                        column: x => x.PayloadId,
                        principalTable: "Payloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repositorys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PayloadId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Full_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repositorys_Payloads_PayloadId",
                        column: x => x.PayloadId,
                        principalTable: "Payloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PayloadId = table.Column<long>(type: "INTEGER", nullable: false),
                    CommitterId = table.Column<long>(type: "INTEGER", nullable: true),
                    Message = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<long>(type: "INTEGER", nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Added = table.Column<string>(type: "TEXT", nullable: true),
                    Removed = table.Column<string>(type: "TEXT", nullable: true),
                    Modified = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commits_Payloads_PayloadId",
                        column: x => x.PayloadId,
                        principalTable: "Payloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commits_PayloadUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "PayloadUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commits_PayloadUsers_CommitterId",
                        column: x => x.CommitterId,
                        principalTable: "PayloadUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commits_AuthorId",
                table: "Commits",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_CommitterId",
                table: "Commits",
                column: "CommitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_PayloadId",
                table: "Commits",
                column: "PayloadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayloadUsers_PayloadId",
                table: "PayloadUsers",
                column: "PayloadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repositorys_PayloadId",
                table: "Repositorys",
                column: "PayloadId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits");

            migrationBuilder.DropTable(
                name: "Repositorys");

            migrationBuilder.DropTable(
                name: "PayloadUsers");

            migrationBuilder.DropTable(
                name: "Payloads");
        }
    }
}
