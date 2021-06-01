using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class appuserv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "User",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "Identity",
                newName: "Post",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "Message",
                schema: "Identity",
                newName: "Message",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                schema: "Identity",
                newName: "IdentityUser",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "Identity",
                newName: "Comment",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                newName: "AspNetUserTokens",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                newName: "AspNetUserRoles",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                newName: "AspNetUserLogins",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                newName: "AspNetUserClaims",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Identity",
                newName: "AspNetRoles",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                newName: "AspNetRoleClaims",
                newSchema: "SocialNetwork");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "SocialNetwork",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Post",
                schema: "SocialNetwork",
                newName: "Post",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Message",
                schema: "SocialNetwork",
                newName: "Message",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                schema: "SocialNetwork",
                newName: "IdentityUser",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "SocialNetwork",
                newName: "Comment",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "SocialNetwork",
                newName: "AspNetUserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "SocialNetwork",
                newName: "AspNetUserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "SocialNetwork",
                newName: "AspNetUserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "SocialNetwork",
                newName: "AspNetUserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "SocialNetwork",
                newName: "AspNetRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "SocialNetwork",
                newName: "AspNetRoleClaims",
                newSchema: "Identity");
        }
    }
}
