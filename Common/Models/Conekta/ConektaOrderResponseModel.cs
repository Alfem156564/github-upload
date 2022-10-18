namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaOrderResponseModel
    {
        [JsonProperty(propertyName: "livemode")]
        public bool Livemode { get; set; }

        [JsonProperty(propertyName: "amount")]
        public int Amount { get; set; }

        [JsonProperty(propertyName: "currency")]
        public string Currency { get; set; }

        [JsonProperty(propertyName: "payment_status")]
        public string PaymentStatus { get; set; }

        [JsonProperty(propertyName: "amount_refunded")]
        public int AmountRefunded { get; set; }

        [JsonProperty(propertyName: "customer_info")]
        public ConektaCustomerInfoResponseModel CustomerInfo { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(propertyName: "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(propertyName: "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(propertyName: "line_items")]
        public ConektaChargesAnItemsResponseModel LineItems { get; set; }

        [JsonProperty(propertyName: "charges")]
        public ConektaChargesAnItemsResponseModel Charges { get; set; }
    }
}
