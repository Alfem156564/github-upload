using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations.PasatiempoDatabase
{
    public partial class NombreMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Personajes",
                schema: "Pasatiempo",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personajes",
                schema: "Pasatiempo",
                table: "Anime");
        }
    }
}
