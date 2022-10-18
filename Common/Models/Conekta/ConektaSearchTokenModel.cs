namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaSearchTokenModel
    {
        [JsonProperty(propertyName: "checkout")]
        public ConektaCheckoutModel Checkout { get; set; }
    }
}
