using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektFinal.Migrations
{
    public partial class neznam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaID",
                table: "FilmDetails");

            migrationBuilder.RenameColumn(
                name: "ProdKucaID",
                table: "FilmDetails",
                newName: "KucaID");

            migrationBuilder.RenameIndex(
                name: "IX_FilmDetails_ProdKucaID",
                table: "FilmDetails",
                newName: "IX_FilmDetails_KucaID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmDetails_ProdKuce_KucaID",
                table: "FilmDetails",
                column: "KucaID",
                principalTable: "ProdKuce",
                principalColumn: "KucaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmDetails_ProdKuce_KucaID",
                table: "FilmDetails");

            migrationBuilder.RenameColumn(
                name: "KucaID",
                table: "FilmDetails",
                newName: "ProdKucaID");

            migrationBuilder.RenameIndex(
                name: "IX_FilmDetails_KucaID",
                table: "FilmDetails",
                newName: "IX_FilmDetails_ProdKucaID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaID",
                table: "FilmDetails",
                column: "ProdKucaID",
                principalTable: "ProdKuce",
                principalColumn: "KucaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
