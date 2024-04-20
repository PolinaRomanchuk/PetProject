using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.SQL.Migrations
{
    /// <inheritdoc />
    public partial class addUserProfileandSomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LoginName");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfoBio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowersCount = table.Column<int>(type: "int", nullable: false),
                    FollowingCount = table.Column<int>(type: "int", nullable: false),
                    PostsCount = table.Column<int>(type: "int", nullable: false),
                    Posts = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.RenameColumn(
                name: "LoginName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
