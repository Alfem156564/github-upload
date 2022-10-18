namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaTokenResponseModel
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "livemode")]
        public bool Livemode { get; set; }

        [JsonProperty(propertyName: "used")]
        public bool Used { get; set; }

        [JsonProperty(propertyName: "checkout")]
        public ConektaCheckoutResponseModel Checkout { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }
    }
}
