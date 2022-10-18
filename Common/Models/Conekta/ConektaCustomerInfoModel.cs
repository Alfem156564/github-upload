namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCustomerInfoModel
    {
        [JsonProperty(propertyName: "customer_id")]
        public string CustomerId { get; set; }
    }
}
