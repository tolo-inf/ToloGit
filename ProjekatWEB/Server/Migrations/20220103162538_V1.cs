using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Igra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Zanr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GodinaIzlaska = table.Column<int>(type: "int", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igra", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nagrada",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivOrg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IgraFKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagrada", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nagrada_Igra_IgraFKID",
                        column: x => x.IgraFKID,
                        principalTable: "Igra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocena",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gameplay = table.Column<int>(type: "int", nullable: false),
                    Story = table.Column<int>(type: "int", nullable: false),
                    Music = table.Column<int>(type: "int", nullable: false),
                    Graphics = table.Column<int>(type: "int", nullable: false),
                    IgraFKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ocena_Igra_IgraFKID",
                        column: x => x.IgraFKID,
                        principalTable: "Igra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prodavnica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenaIgre = table.Column<int>(type: "int", nullable: false),
                    KolicinaProdatih = table.Column<int>(type: "int", nullable: false),
                    IgraFKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prodavnica_Igra_IgraFKID",
                        column: x => x.IgraFKID,
                        principalTable: "Igra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nagrada_IgraFKID",
                table: "Nagrada",
                column: "IgraFKID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_IgraFKID",
                table: "Ocena",
                column: "IgraFKID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavnica_IgraFKID",
                table: "Prodavnica",
                column: "IgraFKID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nagrada");

            migrationBuilder.DropTable(
                name: "Ocena");

            migrationBuilder.DropTable(
                name: "Prodavnica");

            migrationBuilder.DropTable(
                name: "Igra");
        }
    }
}
