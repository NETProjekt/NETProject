using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_Projekt.Data.Migrations
{
    public partial class AddFavouriteList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPositive",
                table: "Raitings",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FavouriteLists",
                columns: table => new
                {
                    ApplicationUserID = table.Column<string>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteLists", x => new { x.ApplicationUserID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_FavouriteLists_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteLists_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteLists_RecipeID",
                table: "FavouriteLists",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteLists");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPositive",
                table: "Raitings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
