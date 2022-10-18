namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaAddressModel
    {
        [JsonProperty(propertyName: "street1")]
        public string Street1 { get; set; }

        [JsonProperty(propertyName: "street2")]
        public string Street2 { get; set; }

        [JsonProperty(propertyName: "city")]
        public string City { get; set; }

        [JsonProperty(propertyName: "state")]
        public string State { get; set; }

        [JsonProperty(propertyName: "country")]
        public string Country { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "residential")]
        public bool Residential { get; set; }

        [JsonProperty(propertyName: "postal_code")]
        public string PostalCode { get; set; }
    }
}
