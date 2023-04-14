using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public record EnergyOffer(
        Guid Id,
        string Country,
        string System,
        string RegionalControlCenter,
        string LoadingZone,
        string NodeId,
        string Description,
        int Quantity,
        double PricePerUnit,
        DateTime Date);

    public class EnergyOfferRegionalControlCenter
    {
        public string RegionalControlCenter { get; set; }
        public int Count { get; set; }
    }

    public class EnergyOfferLoadingZone : EnergyOfferRegionalControlCenter
    {
        public string LoadingZone { get; set; }
    }

    public class EnergyOfferNodeId : EnergyOfferLoadingZone
    {
        public string NodeId { get; set; }
    }
}
