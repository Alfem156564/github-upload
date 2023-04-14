using Data.Contracts;
using Data.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAzure.Api.Definition;

namespace TestAzure.Api.Functions.Graphql.Type
{
    public class OfferType : ObjectType<OfferDefinition>
    {
        protected override void Configure(IObjectTypeDescriptor<OfferDefinition> descriptor)
        {
            descriptor
                .Name("Offer");

            descriptor
                .Field(f => f.ListCertificatesOffer)
                .Resolve(resolver => GetCertificatesOffer(
                        resolver.Service<ICertificatesOfferAccessService>(),
                        resolver.Parent<OfferDefinition>().UserId));

            descriptor
                .Field(f => f.ListCertificatesCounterOffer)
                .Resolve(resolver => GetCertificatesCounterOffer(
                        resolver.Service<ICertificatesCounterOfferDataAccessService>(),
                        resolver.Parent<OfferDefinition>().UserId));

            descriptor
                .Field(f => f.ListEnergyOffer)
                .Resolve(resolver => GetEnergyOffer(
                        resolver.Service<IEnergyOfferAccessService>(),
                        resolver.Parent<OfferDefinition>().UserId));

            descriptor
                .Ignore(f => f.UserId);
        }

        public async Task<List<CertificatesOffer>> GetCertificatesOffer(
            ICertificatesOfferAccessService certificatesOfferAccessService,
            Guid userId) =>
            await certificatesOfferAccessService
                .GetCertificatesOffersByUserId(userId)
                .ConfigureAwait(false);

        public async Task<List<CertificatesCounterOffer>> GetCertificatesCounterOffer(
            ICertificatesCounterOfferDataAccessService certificatesCounterOfferDataAccessService,
            Guid userId) =>
            await certificatesCounterOfferDataAccessService
                .GetCounterOfferByUser(userId)
                .ConfigureAwait(false);

        public async Task<List<EnergyOffer>> GetEnergyOffer(
            IEnergyOfferAccessService energyOfferAccessService,
            Guid userId) =>
            await energyOfferAccessService
                .GetEnergyOffersByUser(userId)
                .ConfigureAwait(false);
    }
}
