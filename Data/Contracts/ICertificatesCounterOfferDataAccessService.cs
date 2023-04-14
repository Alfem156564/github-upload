using Data.Models;
using Data.Models.Entities;
namespace Data.Contracts
{
    public interface ICertificatesCounterOfferDataAccessService
    {
        Task<CertificatesCounterOffer> CreateCounterOffer(Guid offerId, int quantity, decimal pricePerUnit, Guid createdByUserId);

        Task<List<CertificatesCounterOffer>> GetCounterOfferByUser(Guid createdBy);
    }
}
