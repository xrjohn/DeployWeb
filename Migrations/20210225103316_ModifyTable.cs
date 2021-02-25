using Microsoft.EntityFrameworkCore.Migrations;

namespace DeployWeb.Migrations
{
    public partial class ModifyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_payloaduser");

            migrationBuilder.DropColumn(
                name: "PusherId",
                table: "t_payload");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "t_commit");

            migrationBuilder.DropColumn(
                name: "CommitterId",
                table: "t_commit");

            migrationBuilder.AlterColumn<string>(
                name: "BranchId",
                table: "t_payload",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "PusherEmail",
                table: "t_payload",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PusherName",
                table: "t_payload",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "t_commit",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "t_commit",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorUserName",
                table: "t_commit",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommitterEmail",
                table: "t_commit",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommitterName",
                table: "t_commit",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommitterUserName",
                table: "t_commit",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "t_branch",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PusherEmail",
                table: "t_payload");

            migrationBuilder.DropColumn(
                name: "PusherName",
                table: "t_payload");

            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "t_commit");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "t_commit");

            migrationBuilder.DropColumn(
                name: "AuthorUserName",
                table: "t_commit");

            migrationBuilder.DropColumn(
                name: "CommitterEmail",
                table: "t_commit");

            migrationBuilder.DropColumn(
                name: "CommitterName",
                table: "t_commit");

            migrationBuilder.DropColumn(
                name: "CommitterUserName",
                table: "t_commit");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "t_payload",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PusherId",
                table: "t_payload",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "t_commit",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommitterId",
                table: "t_commit",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "t_branch",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "t_payloaduser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_payloaduser", x => x.Id);
                });
        }
    }
}
