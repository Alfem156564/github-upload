using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations.PasatiempoDatabase
{
    public partial class spCatalogoDestino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO

                CREATE PROCEDURE TES.prTESMantenimientoCatalogoDestino(
                 @intMovimiento					INT,
                @intTipoCatalogoDestinoKey		INT,
                @vchDescripcion					VARCHAR(MAX),
                @vchUsuarioCaptura				VARCHAR(MAX),
                @vchUsuarioElimina				VARCHAR(MAX),
                @vchErrorMessage				VARCHAR(MAX) output)
                AS


                -- Asigno los valores iniciales
                SET @vchErrorMessage = ''

                IF @intMovimiento = 1
	                BEGIN
		                INSERT INTO TES.CatalogoDestino
                           (vchDescripcion
                           ,dtmFechaRegistro
                           ,vchUsuarioCaptura
                           ,bitActivo
                           ,dtmFechaElimina
                           ,vchUsuarioElimina)
                     VALUES
                           (@vchDescripcion
                           ,GETDATE()
                           ,@vchUsuarioCaptura
                           ,1
                           ,NULL
                           ,NULL)
	                END
	
                IF @intMovimiento = 2
	                BEGIN
		                UPDATE TES.CatalogoDestino
		                SET vchDescripcion = @vchDescripcion
		                WHERE intTipoCatalogoDestinoKey = @intTipoCatalogoDestinoKey
	                END
	
                IF @intMovimiento = 3
	                BEGIN
		                UPDATE TES.CatalogoDestino
		                SET bitActivo = 0,
			                vchUsuarioElimina = @vchUsuarioElimina,
			                dtmFechaElimina = GETDATE()
		                WHERE intTipoCatalogoDestinoKey = @intTipoCatalogoDestinoKey
	                END



                IF @@ERROR <> 0
	                BEGIN
		                SET @vchErrorMessage = 'Error transaccional al dar mantenimiento a la tabla CatalogoDestino en la base de datos'+CHAR(13)+
							                   'Intente de nuevo si persiste el error contacte a Alfem'+CHAR(13)+
							                   'Fuente: prTESMantenimientoCatalogoDestino   Error#'+CONVERT(VARCHAR(10),@@ERROR)
	                END
					select @vchErrorMessage   AS vchErrorMessage
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop PROCEDURE TES.prTESMantenimientoCatalogoDestino");
        }
    }
}
