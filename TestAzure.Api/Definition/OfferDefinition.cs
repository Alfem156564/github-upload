using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAzure.Api.Definition
{
    [JsonObject]
    public class OfferDefinition
    {
        [JsonProperty]
        public Guid UserId { get; set; }

        [JsonProperty]
        public List<CertificatesCounterOffer> ListCertificatesCounterOffer { get; set; }

        [JsonProperty]
        public List<CertificatesOffer> ListCertificatesOffer { get; set; }

        [JsonProperty]
        public List<EnergyOffer> ListEnergyOffer { get; set; }
    }
}
