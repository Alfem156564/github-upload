
using Data.Models;
using Data.Models.Entities;
namespace Data.Contracts
{
    public interface ICertificatesOfferAccessService
    {
        Task<CertificatesOffer> CreateOffer(
            int quantity,
            int? year,
            string country,
            double pricePerUnit,
            Guid createdByUserId);

        Task<CertificatesOffer> GetCertificatesOffer(Guid offerId);

        Task<List<CertificatesOffer>> GetCertificatesOffersByUserId(Guid userId);

        Task<List<CertificatesOffer>> GetCertificatesOpenOffers(
            int? yearMin = default,
            int? yearMax = default,
            string country = null);
    }
}
