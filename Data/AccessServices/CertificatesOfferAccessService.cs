using Data.Contracts;
using Data.Helper;
using Data.Models;
using Data.Models.Entities;
using Data.Providers.Database;
using Microsoft.EntityFrameworkCore;

namespace Data.AccessServices
{
    public class CertificatesOfferAccessService : ICertificatesOfferAccessService
    {
        private readonly GraphDatabaseContext databaseContext;

        public CertificatesOfferAccessService(GraphDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<CertificatesOffer> CreateOffer(
            int quantity,
            int? year,
            string country,
            double pricePerUnit,
            Guid createdByUserId)
        {
            var entity = new CertificatesOfferEntity
            {
                Quantity = quantity,
                Year = year,
                Country = country,
                PricePerUnit = pricePerUnit,
                CreatedBy = createdByUserId,
            };

            await databaseContext.CertificatesOffers
                .AddAsync(entity)
                .ConfigureAwait(false);

            await databaseContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return entity
                .ToCertificatesOffer();
        }

        public async Task<CertificatesOffer> GetCertificatesOffer(Guid offerId)
        {
            var offer = await databaseContext.CertificatesOffers
                .FirstOrDefaultAsync(item => item.Id == offerId && item.IsEnabled)
                .ConfigureAwait(false);

            return offer
                .ToCertificatesOffer();
        }

        public async Task<List<CertificatesOffer>> GetCertificatesOffersByUserId(Guid userId)
        {
            var offersList = await databaseContext.CertificatesOffers
                .Where(item => item.CreatedBy == userId && item.IsEnabled)
                .ToListAsync()
                .ConfigureAwait(false);

            return offersList
                .ToCertificatesOffersList();
        }

        public async Task<List<CertificatesOffer>> GetCertificatesOpenOffers(
            int? yearMin = default,
            int? yearMax = default,
            string country = null)
        {
            var query = databaseContext.CertificatesOffers
                .Where(offer => offer.IsEnabled);

            if (yearMax != null)
            {
                query = query
                    .Where(offer => offer.Year != null && offer.Year <= yearMax);
            }
            if (yearMin != null)
            {
                query = query
                    .Where(offer => offer.Year != null && offer.Year >= yearMin);
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query
                    .Where(offer => offer.Country == country);
            }

            var offersList = await query
                .ToListAsync()
                .ConfigureAwait(false);

            return offersList
                .ToCertificatesOffersList();
        }
    }
}
