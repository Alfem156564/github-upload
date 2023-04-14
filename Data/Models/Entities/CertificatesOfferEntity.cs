using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Entities
{
    [Table("CertificatesOffers")]
    public class CertificatesOfferEntity : GraphEntityBase
    {
        public Guid Id { get; set; } = new Guid();

        public int Quantity { get; set; }

        public int? Year { get; set; }

        public string Country { get; set; }

        public double PricePerUnit { get; set; }

        public List<CertificatesCounterOfferEntity> CertificatesCounterOfferEntities { get; set; }
    }
}
