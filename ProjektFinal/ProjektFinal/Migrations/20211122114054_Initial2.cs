using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektFinal.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaID",
                table: "FilmDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Uloge_FilmDetails_FilmDetailID",
                table: "Uloge");

            migrationBuilder.DropForeignKey(
                name: "FK_Uloge_Glumci_GlumacID",
                table: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_Uloge_FilmDetailID",
                table: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_Uloge_GlumacID",
                table: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_FilmDetails_ProdKucaID",
                table: "FilmDetails");

            migrationBuilder.AlterColumn<long>(
                name: "GlumacID",
                table: "Uloge",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "FilmDetailID",
                table: "Uloge",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FilmDetailFilmId",
                table: "Uloge",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GlumacID1",
                table: "Uloge",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProdKucaID",
                table: "FilmDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProdKucaKucaID",
                table: "FilmDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_FilmDetailFilmId",
                table: "Uloge",
                column: "FilmDetailFilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_GlumacID1",
                table: "Uloge",
                column: "GlumacID1");

            migrationBuilder.CreateIndex(
                name: "IX_FilmDetails_ProdKucaKucaID",
                table: "FilmDetails",
                column: "ProdKucaKucaID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaKucaID",
                table: "FilmDetails",
                column: "ProdKucaKucaID",
                principalTable: "ProdKuce",
                principalColumn: "KucaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uloge_FilmDetails_FilmDetailFilmId",
                table: "Uloge",
                column: "FilmDetailFilmId",
                principalTable: "FilmDetails",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uloge_Glumci_GlumacID1",
                table: "Uloge",
                column: "GlumacID1",
                principalTable: "Glumci",
                principalColumn: "GlumacID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaKucaID",
                table: "FilmDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Uloge_FilmDetails_FilmDetailFilmId",
                table: "Uloge");

            migrationBuilder.DropForeignKey(
                name: "FK_Uloge_Glumci_GlumacID1",
                table: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_Uloge_FilmDetailFilmId",
                table: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_Uloge_GlumacID1",
                table: "Uloge");

            migrationBuilder.DropIndex(
                name: "IX_FilmDetails_ProdKucaKucaID",
                table: "FilmDetails");

            migrationBuilder.DropColumn(
                name: "FilmDetailFilmId",
                table: "Uloge");

            migrationBuilder.DropColumn(
                name: "GlumacID1",
                table: "Uloge");

            migrationBuilder.DropColumn(
                name: "ProdKucaKucaID",
                table: "FilmDetails");

            migrationBuilder.AlterColumn<int>(
                name: "GlumacID",
                table: "Uloge",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "FilmDetailID",
                table: "Uloge",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProdKucaID",
                table: "FilmDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_FilmDetailID",
                table: "Uloge",
                column: "FilmDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_GlumacID",
                table: "Uloge",
                column: "GlumacID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmDetails_ProdKucaID",
                table: "FilmDetails",
                column: "ProdKucaID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaID",
                table: "FilmDetails",
                column: "ProdKucaID",
                principalTable: "ProdKuce",
                principalColumn: "KucaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uloge_FilmDetails_FilmDetailID",
                table: "Uloge",
                column: "FilmDetailID",
                principalTable: "FilmDetails",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uloge_Glumci_GlumacID",
                table: "Uloge",
                column: "GlumacID",
                principalTable: "Glumci",
                principalColumn: "GlumacID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
