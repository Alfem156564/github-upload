namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaPaymentMethodResponseModel
    {
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "exp_month")]
        public string ExpMonth { get; set; }

        [JsonProperty(propertyName: "exp_year")]
        public string ExpYear { get; set; }

        [JsonProperty(propertyName: "auth_code")]
        public string AuthCode { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "last4")]
        public string Last4 { get; set; }

        [JsonProperty(propertyName: "brand")]
        public string Brand { get; set; }

        [JsonProperty(propertyName: "issuer")]
        public string Issuer { get; set; }

        [JsonProperty(propertyName: "account_type")]
        public string AccountType { get; set; }

        [JsonProperty(propertyName: "country")]
        public string Country { get; set; }

        [JsonProperty(propertyName: "fraud_indicators")]
        public List<object> FraudIndicators { get; set; }
    }
}
