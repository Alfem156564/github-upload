namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaDataResponseModel
    {
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "unit_price")]
        public int UnitPrice { get; set; }

        [JsonProperty(propertyName: "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "parent_id")]
        public string ParentId { get; set; }

        [JsonProperty(propertyName: "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(propertyName: "antifraud_info")]
        public object AntifraudInfo { get; set; }

        [JsonProperty(propertyName: "Livemode")]
        public bool livemode { get; set; }

        [JsonProperty(propertyName: "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(propertyName: "currency")]
        public string Currency { get; set; }

        [JsonProperty(propertyName: "device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty(propertyName: "payment_method")]
        public ConektaPaymentMethodResponseModel PaymentMethod { get; set; }

        [JsonProperty(propertyName: "description")]
        public string Description { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }

        [JsonProperty(propertyName: "amount")]
        public int Amount { get; set; }

        [JsonProperty(propertyName: "paid_at")]
        public int PaidAt { get; set; }

        [JsonProperty(propertyName: "fee")]
        public int Fee { get; set; }

        [JsonProperty(propertyName: "customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty(propertyName: "order_id")]
        public string OrderId { get; set; }
    }
}
