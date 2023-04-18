using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations.PasatiempoDatabase
{
    public partial class CatalogoDestino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TES");

            migrationBuilder.CreateTable(
                name: "CatalogoDestino",
                schema: "TES",
                columns: table => new
                {
                    intTipoCatalogoDestinoKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtmFechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vchUsuarioCaptura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bitActivo = table.Column<bool>(type: "bit", nullable: false),
                    dtmFechaElimina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vchUsuarioElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoDestino", x => x.intTipoCatalogoDestinoKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoDestino",
                schema: "TES");
        }
    }
}
