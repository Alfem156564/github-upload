namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaOrderModel
    {
        [JsonProperty(propertyName: "currency")]
        public string Currency { get; set; }

        [JsonProperty(propertyName: "customer_info")]
        public ConektaCustomerInfoModel CustomerInfo { get; set; }

        [JsonProperty(propertyName: "line_items")]
        public List<ConektaLineItemModel> LineItems { get; set; }

        [JsonProperty(propertyName: "charges")]
        public List<ConektaChargeModel> Charges { get; set; }
    }
}
