using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class isEnabled2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_AppUserId",
                schema: "SocialNetwork",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Friends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                schema: "SocialNetwork",
                table: "Friends",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AppUserId",
                schema: "SocialNetwork",
                table: "Friends",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_IdentityUser_AppUserId",
                schema: "SocialNetwork",
                table: "Friends",
                column: "AppUserId",
                principalSchema: "SocialNetwork",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
