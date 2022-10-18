namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCheckoutResponseModel
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "livemode")]
        public bool Livemode { get; set; }

        [JsonProperty(propertyName: "emails_sent")]
        public int EmailsSent { get; set; }

        [JsonProperty(propertyName: "success_url")]
        public string SuccessUrl { get; set; }

        [JsonProperty(propertyName: "failure_url")]
        public string FailureUrl { get; set; }

        [JsonProperty(propertyName: "paid_payments_count")]
        public int PaidPaymentsCount { get; set; }

        [JsonProperty(propertyName: "sms_sent")]
        public int SmsSent { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "recurrent")]
        public bool Recurrent { get; set; }

        [JsonProperty(propertyName: "starts_at")]
        public int StartsAt { get; set; }

        [JsonProperty(propertyName: "expires_at")]
        public int ExpiresAt { get; set; }

        [JsonProperty(propertyName: "allowed_payment_methods")]
        public List<string> AllowedPaymentMethods { get; set; }

        [JsonProperty(propertyName: "exclude_card_networks")]
        public List<object> ExcludeCardNetworks { get; set; }

        [JsonProperty(propertyName: "needs_shipping_contact")]
        public bool NeedsShippingContact { get; set; }

        [JsonProperty(propertyName: "monthly_installments_options")]
        public List<object> MonthlyInstallmentsOptions { get; set; }

        [JsonProperty(propertyName: "monthly_installments_enabled")]
        public bool MonthlyInstallmentsEnabled { get; set; }

        [JsonProperty(propertyName: "force_3ds_flow")]
        public bool Force3dsFlow { get; set; }

        [JsonProperty(propertyName: "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(propertyName: "can_not_expire")]
        public bool CanNotExpire { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "on_demand_enabled")]
        public bool OnDemandEnabled { get; set; }
    }
}
