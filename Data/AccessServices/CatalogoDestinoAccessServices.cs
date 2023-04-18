namespace Data.AccessServices
{
    using Data.Contracts;
    using Data.Models;
    using Data.Models.Entities;
    using Data.Providers.Database;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Data;

    public class CatalogoDestinoAccessServices : ICatalogoDestinoAccessServices
    {
        private readonly PasatiempoDatabaseContext databaseContext;

        public CatalogoDestinoAccessServices(PasatiempoDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public CatalogoDestinoEntity GetCatalogoDestinoById(int intTipoCatalogoDestinoKey) =>
            databaseContext.Catalogos
                .FirstOrDefault(userType => userType.intTipoCatalogoDestinoKey.Equals(intTipoCatalogoDestinoKey));

        public List<CatalogoDestinoEntity> GetCatalogoDestinos() =>
            databaseContext.Catalogos
                .Where(userType => userType.bitActivo)
                .ToList();

        public List<CatalogoDestinoEntity> GetCatalogoDestinosDisabled() =>
            databaseContext.Catalogos
                .Where(userType => !userType.bitActivo)
                .ToList();

        public Task<GenericResult> UpdateCatalogoDestinoAsync(
            int intTipoCatalogoDestinoKey,
            string vchDescripcion) =>
            prTESMantenimientoCatalogoDestino(2, intTipoCatalogoDestinoKey, vchDescripcion, "", "");

        public Task<GenericResult> CreateCatalogoDestinoAsync(
            string vchDescripcion,
            string vchUsuarioCaptura) =>
            prTESMantenimientoCatalogoDestino(1, 0, vchDescripcion, vchUsuarioCaptura, "");

        public Task<GenericResult> DisabledCatalogoDestinoAsync(
            int intTipoCatalogoDestinoKey,
            string vchUsuarioElimina) => 
            prTESMantenimientoCatalogoDestino(3, intTipoCatalogoDestinoKey, "", "", vchUsuarioElimina);

        private async Task<GenericResult> prTESMantenimientoCatalogoDestino(
            int intMovimiento,
            int intTipoCatalogoDestinoKey,
            string vchDescripcion,
            string vchUsuarioCaptura,
            string vchUsuarioElimina)
        {
            try
            {
                var vchErrorMessage = new SqlParameter();
                vchErrorMessage.ParameterName = "@vchErrorMessage";
                vchErrorMessage.SqlDbType = SqlDbType.VarChar;
                vchErrorMessage.Size = int.MaxValue;
                vchErrorMessage.Direction = ParameterDirection.Output;

                var detalle = await databaseContext.SP_TESMantenimientoCatalogoDestino.FromSqlInterpolated($"EXEC  TES.prTESMantenimientoCatalogoDestino  @intMovimiento={intMovimiento},@intTipoCatalogoDestinoKey={intTipoCatalogoDestinoKey},@vchDescripcion={vchDescripcion},@vchUsuarioCaptura={vchUsuarioCaptura},@vchUsuarioElimina={vchUsuarioElimina}, @vchErrorMessage={vchErrorMessage} OUT").ToListAsync();

                return new GenericResult
                {
                    vchErrorMessage = vchErrorMessage.Value.ToString()
                };
            }catch(Exception ex)
            {
                return new GenericResult
                {
                    vchErrorMessage = ex.ToString()
                };
            }
        }
    }
}
