using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInNest",
                table: "GamePieces");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "GamePieces",
                newName: "CurrentPosition");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "GamePlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "GamePlayers");

            migrationBuilder.RenameColumn(
                name: "CurrentPosition",
                table: "GamePieces",
                newName: "Color");

            migrationBuilder.AddColumn<bool>(
                name: "IsInNest",
                table: "GamePieces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
