using Data.Contracts;
using Data.Models.Entities;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helper
{
    public static class EntitiesHelpers
    {
        public static CertificatesOffer ToCertificatesOffer(this CertificatesOfferEntity entity) => entity == null
            ? null
            : new CertificatesOffer(entity.Id,
                entity.Quantity,
                entity.Year,
                entity.Country,
                entity.PricePerUnit,
                entity.CreatedDate,
                entity.CreatedBy,
                entity.CertificatesCounterOfferEntities.ToCertificatesCounterOffersList());

        public static List<CertificatesOffer> ToCertificatesOffersList(this List<CertificatesOfferEntity> entities) => (entities ?? new List<CertificatesOfferEntity>()).Select(ToCertificatesOffer).ToList();

        public static CertificatesCounterOffer ToCertificatesCounterOffer(this CertificatesCounterOfferEntity entity) => entity == null
            ? null
            : new CertificatesCounterOffer(entity.Id, entity.Quantity, entity.PricePerUnit, entity.CreatedDate, entity.CreatedBy);

        public static List<CertificatesCounterOffer> ToCertificatesCounterOffersList(this List<CertificatesCounterOfferEntity> entities) => (entities ?? new List<CertificatesCounterOfferEntity>()).Select(ToCertificatesCounterOffer).ToList();

        public static EnergyOffer ToEnergyOffer(this EnergyOfferEntity entity,
            ICommonSerializer? serializer = null) => entity == null
            ? null
            : new EnergyOffer(
                entity.Id,
                entity.Country,
                entity.System,
                entity.RegionalControlCenter,
                entity.LoadingZone,
                entity.NodeId,
                entity.Description,
                entity.Quantity,
                entity.PricePerUnit,
                entity.Date);

        public static List<EnergyOffer> ToEnergyOffersList(this List<EnergyOfferEntity> entities,
            ICommonSerializer? serializer = null) =>
            (entities ?? new List<EnergyOfferEntity>()).Select(entity => ToEnergyOffer(entity, serializer)).ToList();
    }
}
