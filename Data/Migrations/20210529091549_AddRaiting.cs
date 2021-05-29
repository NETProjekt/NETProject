using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_Projekt.Data.Migrations
{
    public partial class AddRaiting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raitings",
                columns: table => new
                {
                    ApplicationUserID = table.Column<string>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false),
                    IsPositive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raitings", x => new { x.ApplicationUserID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_Raitings_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Raitings_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raitings_RecipeID",
                table: "Raitings",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raitings");
        }
    }
}
