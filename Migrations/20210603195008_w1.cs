using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class w1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "SocialNetwork",
                columns: table => new
                {
                    LikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    likedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes",
                schema: "SocialNetwork");
        }
    }
}
