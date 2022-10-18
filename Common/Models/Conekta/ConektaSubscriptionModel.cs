namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaSubscriptionModel
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(propertyName: "subscription_start")]
        public int SubscriptionStart { get; set; }

        [JsonProperty(propertyName: "trial_end")]
        public int TrialEnd { get; set; }

        [JsonProperty(propertyName: "plan_id")]
        public string PlanId { get; set; }

        [JsonProperty(propertyName: "customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty(propertyName: "customer_custom_reference")]
        public string CustomerCustomReference { get; set; }

        [JsonProperty(propertyName: "card_id")]
        public string CardId { get; set; }
    }
}
