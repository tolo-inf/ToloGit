using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikFKID",
                table: "Ocena",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocena_KorisnikFKID",
                table: "Ocena",
                column: "KorisnikFKID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocena_Korisnik_KorisnikFKID",
                table: "Ocena",
                column: "KorisnikFKID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocena_Korisnik_KorisnikFKID",
                table: "Ocena");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Ocena_KorisnikFKID",
                table: "Ocena");

            migrationBuilder.DropColumn(
                name: "KorisnikFKID",
                table: "Ocena");
        }
    }
}
