namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCustomerInfoResponseModel
    {
        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "phone")]
        public string Phone { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "corporate")]
        public bool Corporate { get; set; }

        [JsonProperty(propertyName: "customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }
    }
}
