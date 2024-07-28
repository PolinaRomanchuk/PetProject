using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.SQL.Migrations
{
    /// <inheritdoc />
    public partial class updateAddComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentedPostId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentedPostId",
                table: "Comments",
                column: "CommentedPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_CommentedPostId",
                table: "Comments",
                column: "CommentedPostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_CommentedPostId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentedPostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentedPostId",
                table: "Comments");
        }
    }
}
