using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class ZmianaPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_userID",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_userID",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserID",
                table: "Post",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserID",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_UserID",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Post",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Post_userID",
                table: "Post",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_userID",
                table: "Post",
                column: "userID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
