using Data.Contracts;
using Data.Models;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAzure.Api.Definition;
using TestAzure.Api.Helpers;

namespace TestAzure.Api.Functions.Graphql
{
    public class Query
    {

        public Query(
               IHttpContextAccessor contextAccessor)
           //: base(contextAccessor)
        {
        }

        private readonly Guid userId = new Guid("51c28a81-e63d-476e-8b45-d2fe3284b4fe");

        public Task<List<CertificatesOffer>> GetCertificatesOffers([Service] ICertificatesOfferAccessService certificatesOfferAccessService) =>
            certificatesOfferAccessService.GetCertificatesOpenOffers();

        public Task<List<CertificatesOffer>> GetMyCertificatesOffers([Service] ICertificatesOfferAccessService certificatesOfferAccessService) =>
            certificatesOfferAccessService.GetCertificatesOffersByUserId(userId);

        public Task<List<EnergyOfferRegionalControlCenter>> GetEnergyOffersCountByCountry([Service] IEnergyOfferAccessService energyAccessService,
            string country) =>
            energyAccessService.GetEnergyOffersCountByCountry(country: country);

        public Task<List<EnergyOfferLoadingZone>> GetEnergyOffersCountByRegionalControlCenter([Service] IEnergyOfferAccessService energyAccessService,
            string regionalControlCenter) =>
            energyAccessService.GetEnergyOffersCountByRegionalControlCenter(regionalControlCenter: regionalControlCenter);

        public Task<List<EnergyOfferNodeId>> GetEnergyOffersCountByLoadingZone([Service] IEnergyOfferAccessService energyAccessService,
            string regionalControlCenter,
            string loadingZone) =>
            energyAccessService.GetEnergyOffersCountByLoadingZone(regionalControlCenter: regionalControlCenter,
                loadingZone: loadingZone);

        public Task<List<EnergyOffer>> GetEnergyOffersCountByNodeId([Service] IEnergyOfferAccessService energyAccessService,
            string regionalControlCenter,
            string loadingZone,
            string nodeId,
            int page,
            int? pageSize = null)
        {
            int count = (pageSize != null) ? pageSize.Value : 20;

            return energyAccessService.GetEnergyOffersCountByNodeId(regionalControlCenter: regionalControlCenter,
                loadingZone: loadingZone,
                nodeId: nodeId,
                count: count,
                page: page);
        }
    }
}
