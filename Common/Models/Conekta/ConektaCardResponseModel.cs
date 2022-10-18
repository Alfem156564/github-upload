namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCardResponseModel
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(propertyName: "last4")]
        public string Last4 { get; set; }

        [JsonProperty(propertyName: "bin")]
        public string Bin { get; set; }

        [JsonProperty(propertyName: "card_type")]
        public string CardType { get; set; }

        [JsonProperty(propertyName: "exp_month")]
        public string ExpMonth { get; set; }

        [JsonProperty(propertyName: "exp_year")]
        public string ExpYear { get; set; }

        [JsonProperty(propertyName: "brand")]
        public string Brand { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "parent_id")]
        public string ParentId { get; set; }

        [JsonProperty(propertyName: "default")]
        public bool Default { get; set; }

        [JsonProperty(propertyName: "visible_on_checkout")]
        public bool VisibleOnCheckout { get; set; }
    }
}
