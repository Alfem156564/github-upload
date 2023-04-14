using Data.Contracts;
using Data.Models;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestAzure.Api.Definition;
using TestAzure.Api.Helpers;

namespace TestAzure.Api.Functions.Graphql
{
    public class Mutation
    {

        public Mutation(
               IHttpContextAccessor contextAccessor)
           //: base(contextAccessor)
        {
        }

        private readonly Guid userId = new Guid("51c28a81-e63d-476e-8b45-d2fe3284b4fe");


        public async Task<CertificatesCounterOffer> CreateCounterOffer(
            Guid offerId,
            CertificatesCounterOffer counterOffer,
            [Service] ICertificatesCounterOfferDataAccessService certificatesOfferManager)
        {
            var result = await certificatesOfferManager
                .CreateCounterOffer(
                    offerId,
                    counterOffer.Quantity,
                    counterOffer.PricePerUnit,
                    userId)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<CertificatesOffer> CreateCertificatesOffer(
            CertificatesOfferRequest offer,
            [Service] ICertificatesOfferAccessService celCertificatesOfferManager)
        {
            var result = await celCertificatesOfferManager
                .CreateOffer(
                    offer.Quantity,
                    offer.Year,
                    offer.Country,
                    offer.PricePerUnit,
                    userId)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<EnergyOffer> CreateEnergyOffer(
            [Service] IEnergyOfferAccessService energyAccessService,
            EnergyOfferDefinition energyOfferDefinition)
        {
            var result = await energyAccessService
                .CreateEnergyOffer(
                    energyOfferDefinition.Country,
                    energyOfferDefinition.LoadingZone,
                    energyOfferDefinition.NodeId,
                    energyOfferDefinition.PricePerUnit,
                    energyOfferDefinition.Quantity,
                    energyOfferDefinition.RegionalControlCenter,
                    energyOfferDefinition.System,
                    energyOfferDefinition.Description,
                    energyOfferDefinition.Date,
                    userId)
                .ConfigureAwait(false);

            return result;
        }
    }
}
