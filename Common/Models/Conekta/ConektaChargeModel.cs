namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaChargeModel
    {
        [JsonProperty(propertyName: "payment_method")]
        public ConektaCreateCardModel payment_method { get; set; }
    }
}
