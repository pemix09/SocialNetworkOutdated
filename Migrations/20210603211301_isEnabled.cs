using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class isEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<bool>(
                name: "isEnabled",
                schema: "SocialNetwork",
                table: "IdentityUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Friends",
                schema: "SocialNetwork",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    friendUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Friends_IdentityUser_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "SocialNetwork",
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AppUserId",
                schema: "SocialNetwork",
                table: "Friends",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends",
                schema: "SocialNetwork");

            migrationBuilder.DropColumn(
                name: "isEnabled",
                schema: "SocialNetwork",
                table: "IdentityUser");

            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "SocialNetwork",
                columns: table => new
                {
                    LikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    likedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeID);
                    table.ForeignKey(
                        name: "FK_Likes_IdentityUser_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "SocialNetwork",
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AppUserId",
                schema: "SocialNetwork",
                table: "Likes",
                column: "AppUserId");
        }
    }
}
