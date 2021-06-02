using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class appuserv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserInfoID",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_userID",
                schema: "SocialNetwork",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_userID",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropTable(
                name: "User",
                schema: "SocialNetwork");

            migrationBuilder.DropIndex(
                name: "IX_Post_userID",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Message_userID",
                schema: "SocialNetwork",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserInfoID",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserInfoID",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                schema: "SocialNetwork",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                schema: "SocialNetwork",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userID",
                schema: "SocialNetwork",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_AppUserId",
                schema: "SocialNetwork",
                table: "Post",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_AppUserId",
                schema: "SocialNetwork",
                table: "Message",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AppUserId",
                schema: "SocialNetwork",
                table: "Comment",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Comment",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Message",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Post",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_AppUserId",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Message_AppUserId",
                schema: "SocialNetwork",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AppUserId",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                schema: "SocialNetwork",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                schema: "SocialNetwork",
                table: "Message",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                schema: "SocialNetwork",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoID",
                schema: "SocialNetwork",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                schema: "SocialNetwork",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    base64Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nickname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    stringID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_userID",
                schema: "SocialNetwork",
                table: "Post",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_userID",
                schema: "SocialNetwork",
                table: "Message",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserInfoID",
                schema: "SocialNetwork",
                table: "Comment",
                column: "UserInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserInfoID",
                schema: "SocialNetwork",
                table: "Comment",
                column: "UserInfoID",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_userID",
                schema: "SocialNetwork",
                table: "Message",
                column: "userID",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_userID",
                schema: "SocialNetwork",
                table: "Post",
                column: "userID",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
