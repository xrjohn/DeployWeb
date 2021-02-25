using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeployWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RepositoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ref = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    BranchName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_commit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CommitterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Added = table.Column<string>(type: "TEXT", nullable: true),
                    Removed = table.Column<string>(type: "TEXT", nullable: true),
                    Modified = table.Column<string>(type: "TEXT", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_commit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_payload",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ref = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    RepositoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    PusherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Head_commitId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CommitIds = table.Column<string>(type: "TEXT", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_payload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_payloaduser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_payloaduser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_repository",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Full_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_repository", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_solution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SolutionName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    FtpAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    FtpAccount = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FtpPassword = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_solution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_transcationrecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromSolutionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToSolutionId = table.Column<int>(type: "INTEGER", nullable: false),
                    AddLists = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyLists = table.Column<string>(type: "TEXT", nullable: true),
                    RemoveLists = table.Column<string>(type: "TEXT", nullable: true),
                    SoftRemove = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_transcationrecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_branch");

            migrationBuilder.DropTable(
                name: "t_commit");

            migrationBuilder.DropTable(
                name: "t_payload");

            migrationBuilder.DropTable(
                name: "t_payloaduser");

            migrationBuilder.DropTable(
                name: "t_repository");

            migrationBuilder.DropTable(
                name: "t_solution");

            migrationBuilder.DropTable(
                name: "t_transcationrecord");
        }
    }
}
