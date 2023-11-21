using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomisSamochodowy.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RodzajNadwozia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajNadwozia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RodzajPaliwa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajPaliwa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samochod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PojemnoscSilnika = table.Column<float>(type: "real", nullable: false),
                    Przebieg = table.Column<float>(type: "real", nullable: false),
                    NumerVIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    RodzajNadwoziaId = table.Column<int>(type: "int", nullable: false),
                    RodzajPaliwaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samochod_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Samochod_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Samochod_RodzajNadwozia_RodzajNadwoziaId",
                        column: x => x.RodzajNadwoziaId,
                        principalTable: "RodzajNadwozia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Samochod_RodzajPaliwa_RodzajPaliwaId",
                        column: x => x.RodzajPaliwaId,
                        principalTable: "RodzajPaliwa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samochod_MarkaId",
                table: "Samochod",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Samochod_ModelId",
                table: "Samochod",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Samochod_RodzajNadwoziaId",
                table: "Samochod",
                column: "RodzajNadwoziaId");

            migrationBuilder.CreateIndex(
                name: "IX_Samochod_RodzajPaliwaId",
                table: "Samochod",
                column: "RodzajPaliwaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samochod");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "RodzajNadwozia");

            migrationBuilder.DropTable(
                name: "RodzajPaliwa");
        }
    }
}
