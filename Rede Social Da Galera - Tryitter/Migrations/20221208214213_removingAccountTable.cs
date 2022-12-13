using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rede_Social_Da_Galera___Tryitter.Migrations
{
    public partial class removingAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Accounts_AccountId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Accounts_AccountId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Students_AccountId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Posts",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AccountId",
                table: "Posts",
                newName: "IX_Posts_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Students_StudentId",
                table: "Posts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Students_StudentId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Posts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_StudentId",
                table: "Posts",
                newName: "IX_Posts_AccountId");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AccountId",
                table: "Students",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Accounts_AccountId",
                table: "Posts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Accounts_AccountId",
                table: "Students",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
