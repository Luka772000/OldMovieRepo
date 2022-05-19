using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektFinal.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "FilmDetails");

            migrationBuilder.DropTable(
                name: "Glumci");

            migrationBuilder.DropTable(
                name: "ProdKuce");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    YearOfBirth = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorID);
                });

            migrationBuilder.CreateTable(
                name: "ProductionHouses",
                columns: table => new
                {
                    KucaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKuce = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionHouses", x => x.KucaID);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Earnings = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    YearOfProduction = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    KucaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Films_ProductionHouses_KucaID",
                        column: x => x.KucaID,
                        principalTable: "ProductionHouses",
                        principalColumn: "KucaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_Roles_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ActorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_KucaID",
                table: "Films",
                column: "KucaID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ActorID",
                table: "Roles",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_FilmID",
                table: "Roles",
                column: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "ProductionHouses");

            migrationBuilder.CreateTable(
                name: "Glumci",
                columns: table => new
                {
                    GlumacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodinaRodenja = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImeGlumca = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                name: "FilmDetails",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodinaProdukcije = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    KucaID = table.Column<int>(type: "int", nullable: false),
                    Ukupnazarada = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDetails", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_FilmDetails_ProdKuce_KucaID",
                        column: x => x.KucaID,
                        principalTable: "ProdKuce",
                        principalColumn: "KucaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    GlumacID = table.Column<int>(type: "int", nullable: false),
                    ImeUloge = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                    table.ForeignKey(
                        name: "FK_Uloge_FilmDetails_FilmID",
                        column: x => x.FilmID,
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
                name: "IX_FilmDetails_KucaID",
                table: "FilmDetails",
                column: "KucaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_FilmID",
                table: "Uloge",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Uloge_GlumacID",
                table: "Uloge",
                column: "GlumacID");
        }
    }
}
