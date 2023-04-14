using Data.Contracts;
using Data.Helper;
using Data.Models;
using Data.Models.Entities;
using Data.Providers.Database;
using Microsoft.EntityFrameworkCore;

namespace Data.AccessServices
{
    public class CertificatesCounterOfferDataAccessService : ICertificatesCounterOfferDataAccessService
    {
        private readonly GraphDatabaseContext databaseContext;

        public CertificatesCounterOfferDataAccessService(GraphDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<CertificatesCounterOffer> CreateCounterOffer(Guid offerId, int quantity, decimal pricePerUnit, Guid createdByUserId)
        {
            var entity = new CertificatesCounterOfferEntity
            {
                CertificatesOfferEntityId = offerId,
                Quantity = quantity,
                PricePerUnit = pricePerUnit,
                CreatedBy = createdByUserId
            };

            await databaseContext.CertificatesCounterOffers
                .AddAsync(entity)
                .ConfigureAwait(false);

            await databaseContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return entity
                .ToCertificatesCounterOffer();
        }

        public async Task<List<CertificatesCounterOffer>> GetCounterOfferByUser(Guid createdBy)
        {
            {
                var offersList = await databaseContext.CertificatesCounterOffers
                    .Where(energyOffer => energyOffer.CreatedBy == createdBy && energyOffer.IsEnabled)
                    .ToListAsync()
                    .ConfigureAwait(false);

                return offersList
                    .ToCertificatesCounterOffersList();
            }
        }
    }
}
