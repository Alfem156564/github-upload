namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaClienteModel
    {
        [JsonProperty(propertyName: "livemode")]
        public bool Livemode { get; set; } = false;

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "phone")]
        public string Phone { get; set; }

        [JsonProperty(propertyName: "default_shipping_contact_id")]
        public string DefaultShippingContactId { get; set; }

        [JsonProperty(propertyName: "subscription")]
        public ConektaSubscriptionModel Subscription { get; set; }

        [JsonProperty(propertyName: "id")]
        public string? Id { get; set; }

        [JsonProperty(propertyName: "object")]
        public string? Object { get; set; }

        [JsonProperty(propertyName: "created_at")]
        public string? CreatedAt { get; set; }

        [JsonProperty(propertyName: "corporate")]
        public bool Corporate { get; set; } = false;

        [JsonProperty(propertyName: "custom_reference")]
        public string? CustomReference { get; set; }

        [JsonProperty(propertyName: "default_payment_source_id")]
        public string DefaultPaymentSourceId { get; set; }

        [JsonProperty(propertyName: "payment_sources")]
        public ConektaPaymentSourceModel PaymentSources { get; set; }

        [JsonProperty(propertyName: "shipping_contacts")]
        public ConektaPaymentSourceModel ShippingContacts { get; set; }
    }
}
