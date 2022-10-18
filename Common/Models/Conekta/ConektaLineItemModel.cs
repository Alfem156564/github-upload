namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaLineItemModel
    {
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "unit_price")]
        public int UnitPrice { get; set; }

        [JsonProperty(propertyName: "quantity")]
        public int Quantity { get; set; }
    }
}
