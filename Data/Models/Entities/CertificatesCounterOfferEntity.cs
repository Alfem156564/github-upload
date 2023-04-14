using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Entities
{
    [Table("CertificatesCounterOffers")]
    public class CertificatesCounterOfferEntity : GraphEntityBase
    {
        public Guid Id { get; set; } = new Guid();

        [Column("CertificatesOfferId")]
        public Guid CertificatesOfferEntityId { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }
    }
}
