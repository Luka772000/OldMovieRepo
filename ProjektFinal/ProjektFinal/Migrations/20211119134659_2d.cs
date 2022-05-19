using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektFinal.Migrations
{
    public partial class _2d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdKucaID",
                table: "FilmDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Glumci",
                columns: table => new
                {
                    GlumacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeGlumca = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GodinaRodenja = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MjestoRodenja = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumci", x => x.GlumacID);
                });

            migrationBuilder.CreateTable(
                name: "ProdKuce",
                columns: table => new
                {
                    KucaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKuce = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdKuce", x => x.KucaID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeUloge = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GlumacID = table.Column<int>(type: "int", nullable: false),
                    FilmDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                    table.ForeignKey(
                        name: "FK_Uloge_FilmDetails_FilmDetailID",
                        column: x => x.FilmDetailID,
                        principalTable: "FilmDetails",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uloge_Glumci_GlumacID",
                        column: x => x.GlumacID,
                        principalTable: "Glumci",
                        principalColumn: "GlumacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmDetails_ProdKucaID",
                table: "FilmDetails",
                column: "ProdKucaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_FilmDetailID",
                table: "Uloge",
                column: "FilmDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_GlumacID",
                table: "Uloge",
                column: "GlumacID");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaID",
                table: "FilmDetails",
                column: "ProdKucaID",
                principalTable: "ProdKuce",
                principalColumn: "KucaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmDetails_ProdKuce_ProdKucaID",
                table: "FilmDetails");

            migrationBuilder.DropTable(
                name: "ProdKuce");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Glumci");

            migrationBuilder.DropIndex(
                name: "IX_FilmDetails_ProdKucaID",
                table: "FilmDetails");

            migrationBuilder.DropColumn(
                name: "ProdKucaID",
                table: "FilmDetails");
        }
    }
}
