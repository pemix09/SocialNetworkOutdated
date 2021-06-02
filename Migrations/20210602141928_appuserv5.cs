using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class appuserv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserTokens");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                schema: "SocialNetwork",
                table: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                schema: "SocialNetwork",
                newName: "User",
                newSchema: "SocialNetwork");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SocialNetwork",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_AppUserId",
                schema: "SocialNetwork",
                table: "Comment",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_AppUserId",
                schema: "SocialNetwork",
                table: "Message",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_AppUserId",
                schema: "SocialNetwork",
                table: "Post",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_AppUserId",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_AppUserId",
                schema: "SocialNetwork",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_AppUserId",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "SocialNetwork",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "SocialNetwork",
                newName: "IdentityUser",
                newSchema: "SocialNetwork");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                schema: "SocialNetwork",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_IdentityUser_UserId",
                schema: "SocialNetwork",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
