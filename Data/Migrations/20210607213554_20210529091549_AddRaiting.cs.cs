using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_Projekt.Data.Migrations
{
    public partial class _20210529091549_AddRaitingcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favourite",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPositive",
                table: "Raitings",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favourite",
                table: "Recipes");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPositive",
                table: "Raitings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
