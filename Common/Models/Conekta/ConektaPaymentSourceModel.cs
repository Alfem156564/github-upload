namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaPaymentSourceModel
    {
        [JsonProperty(propertyName: "object")]
        public string Object { get; set; } = "list";

        [JsonProperty(propertyName: "has_more")]
        public bool HasMore { get; set; } = false;

        [JsonProperty(propertyName: "total")]
        public int Total { get; set; } = 0;

        [JsonProperty(propertyName: "data")]
        public List<ConektaDataModel> Data { get; set; } = new List<ConektaDataModel>();
    }
}
