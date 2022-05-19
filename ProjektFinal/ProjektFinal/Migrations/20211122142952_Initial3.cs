using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektFinal.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilmDetailID",
                table: "Uloge",
                newName: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "Uloge",
                newName: "FilmDetailID");
        }
    }
}
