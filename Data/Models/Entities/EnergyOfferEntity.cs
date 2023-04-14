using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.Entities
{
    [Table("EnergyOffer")]
    public class EnergyOfferEntity : GraphEntityBase
    {
        public Guid Id { get; set; } = new Guid();

        public string Country { get; set; }

        public string System { get; set; }

        public string RegionalControlCenter { get; set; }

        public string LoadingZone { get; set; }

        public string NodeId { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double PricePerUnit { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
