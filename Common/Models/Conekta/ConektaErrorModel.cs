namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaErrorModel
    {
        [JsonProperty(propertyName: "details")]
        public List<ConektaDetailModel> Details { get; set; }

        [JsonProperty(propertyName: "object")]
        public string Object { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "log_id")]
        public string LogId { get; set; }
    }
}
