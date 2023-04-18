namespace Data.Contracts
{
    using Common.Models;
    using Data.Models;
    using Data.Models.Entities;

    public interface ICatalogoDestinoAccessServices
    {
        CatalogoDestinoEntity GetCatalogoDestinoById(int intTipoCatalogoDestinoKey);

        List<CatalogoDestinoEntity> GetCatalogoDestinos();

        public List<CatalogoDestinoEntity> GetCatalogoDestinosDisabled();

        Task<GenericResult> UpdateCatalogoDestinoAsync(
            int intTipoCatalogoDestinoKey,
            string vchDescripcion);

        Task<GenericResult> CreateCatalogoDestinoAsync(
            string vchDescripcion,
            string vchUsuarioCaptura);

        Task<GenericResult> DisabledCatalogoDestinoAsync(
            int intTipoCatalogoDestinoKey,
            string vchUsuarioElimina);
    }
}
