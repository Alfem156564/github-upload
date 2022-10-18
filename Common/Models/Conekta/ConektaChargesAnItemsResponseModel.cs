namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaChargesAnItemsResponseModel
    {
        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "has_more")]
        public bool HasMore { get; set; }

        [JsonProperty(propertyName: "total")]
        public int Total { get; set; }

        [JsonProperty(propertyName: "data")]
        public List<ConektaDataResponseModel> Data { get; set; }
    }
}
