using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAzure.Api.Definition
{
    [JsonObject]
    public class EnergyOfferDefinition
    {
        [JsonProperty]
        public string Country { get; set; }

        [JsonProperty]
        public string LoadingZone { get; set; }

        [JsonProperty]
        public string NodeId { get; set; }

        [JsonProperty]
        public double PricePerUnit { get; set; }

        [JsonProperty]
        public int Quantity { get; set; }

        [JsonProperty]
        public string RegionalControlCenter { get; set; }

        [JsonProperty]
        public string System { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public DateTime Date { get; set; }

        [JsonProperty]
        public string OrderAccount { get; set; }
    }
}
