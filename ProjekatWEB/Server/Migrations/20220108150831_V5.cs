using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDProdavnice",
                table: "Prodavnica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDProdavnice",
                table: "Prodavnica",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
