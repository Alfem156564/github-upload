using Data.Contracts;
using Data.Helper;
using Data.Models;
using Data.Models.Entities;
using Data.Providers.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.AccessServices
{
    public class EnergyOfferAccessService : IEnergyOfferAccessService
    {
        private readonly GraphDatabaseContext databaseContext;

        private readonly ICommonSerializer serializer;

        public EnergyOfferAccessService(GraphDatabaseContext databaseContext,
            ICommonSerializer serializer)
        {
            this.databaseContext = databaseContext;
            this.serializer = serializer;
        }

        public async Task<List<EnergyOfferRegionalControlCenter>> GetEnergyOffersCountByCountry(
            string country = null)
        {
            Expression<Func<EnergyOfferEntity, bool>> expression = energy => energy.IsEnabled;

            if (!string.IsNullOrEmpty(country))
            {
                expression = CombineExpressions<EnergyOfferEntity>.CombineExpressionsAnd(expression, energy => energy.Country == country);
            }

            var query = databaseContext.EnergyOffers
                .Where(expression)
                .GroupBy(energy => energy.RegionalControlCenter)
                .Select(g => new EnergyOfferRegionalControlCenter { RegionalControlCenter = g.Key, Count = g.Count() });

            return await query
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<EnergyOfferLoadingZone>> GetEnergyOffersCountByRegionalControlCenter(
            string regionalControlCenter)
        {
            var query = databaseContext.EnergyOffers
                .Where(energy => energy.IsEnabled && energy.RegionalControlCenter == regionalControlCenter)
                .GroupBy(energy => energy.LoadingZone)
                .Select(g => new EnergyOfferLoadingZone { LoadingZone = g.Key, RegionalControlCenter = regionalControlCenter, Count = g.Count() });

            return await query
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<EnergyOfferNodeId>> GetEnergyOffersCountByLoadingZone(
            string regionalControlCenter,
            string loadingZone)
        {
            var query = databaseContext.EnergyOffers
                .Where(energy => energy.IsEnabled && energy.LoadingZone == loadingZone && energy.RegionalControlCenter == regionalControlCenter)
                .GroupBy(energy => energy.NodeId)
                .Select(g => new EnergyOfferNodeId { NodeId = g.Key, LoadingZone = loadingZone, RegionalControlCenter = regionalControlCenter, Count = g.Count() });

            return await query
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<EnergyOffer>> GetEnergyOffersCountByNodeId(
            string regionalControlCenter,
            string loadingZone,
            string nodeId,
            int count,
            int page)
        {
            var skip = count * (page - 1);

            var query = databaseContext.EnergyOffers
                .Where(energy =>energy.IsEnabled && energy.NodeId == nodeId && energy.LoadingZone == loadingZone && energy.RegionalControlCenter == regionalControlCenter)
                .OrderBy(x => x.CreatedDate)
                .Skip(skip)
                .Take(count);

            var enerngies = await query
                .ToListAsync()
                .ConfigureAwait(false);

            return enerngies
                .ToEnergyOffersList();
        }

        public bool CanPage(string regionalControlCenter,
            string loadingZone,
            string nodeId,
            int count,
            int page)
        {
            var total = databaseContext.EnergyOffers
                .Where(energy => energy.IsEnabled && energy.NodeId == nodeId && energy.LoadingZone == loadingZone && energy.RegionalControlCenter == regionalControlCenter)
                .Count();

            var skip = count * (page - 1);

            return skip < total;
        }

        public async Task<EnergyOffer> CreateEnergyOffer(
            string country,
            string loadingZone,
            string nodeId,
            double pricePerUnit,
            int quantity,
            string regionalControlCenter,
            string system,
            DateTime date,
            Guid createdBy)
        {
            EnergyOfferEntity energyOffer = new EnergyOfferEntity
            {
                Country = country,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                IsEnabled = true,
                LoadingZone = loadingZone,
                NodeId = nodeId,
                PricePerUnit = pricePerUnit,
                Quantity = quantity,
                RegionalControlCenter = regionalControlCenter,
                System = system,
                Date = date,
            };

            await databaseContext.EnergyOffers
                .AddAsync(energyOffer)
                .ConfigureAwait(false);

            await databaseContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return energyOffer
                .ToEnergyOffer();
        }

        public async Task<List<EnergyOffer>> GetEnergyOffersByUser(Guid createdBy)
        {
            {
                var offersList = await databaseContext.EnergyOffers
                    .Where(energyOffer => energyOffer.CreatedBy == createdBy && energyOffer.IsEnabled)
                    .ToListAsync()
                    .ConfigureAwait(false);

                return offersList
                    .ToEnergyOffersList();
            }
        }
    }
}
