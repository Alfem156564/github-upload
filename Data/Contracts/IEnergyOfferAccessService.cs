
using Data.Models;
using Data.Models.Entities;
namespace Data.Contracts
{
    public interface IEnergyOfferAccessService
    {
        Task<List<EnergyOfferRegionalControlCenter>> GetEnergyOffersCountByCountry(
            string country = null);
        Task<List<EnergyOfferLoadingZone>> GetEnergyOffersCountByRegionalControlCenter(
            string regionalControlCenter);
        Task<List<EnergyOfferNodeId>> GetEnergyOffersCountByLoadingZone(
            string regionalControlCenter,
            string loadingZone);
        Task<List<EnergyOffer>> GetEnergyOffersCountByNodeId(
            string regionalControlCenter,
            string loadingZone,
            string nodeId,
            int count,
            int page);
        bool CanPage(string regionalControlCenter,
            string loadingZone,
            string nodeId,
            int count,
            int page);
        Task<EnergyOffer> CreateEnergyOffer(
           string country,
           string loadingZone,
           string nodeId,
           double pricePerUnit,
           int quantity,
           string regionalControlCenter,
           string system,
            string description,
           DateTime date,
           Guid createdBy);
        Task<List<EnergyOffer>> GetEnergyOffersByUser(Guid createdBy);
    }
}
