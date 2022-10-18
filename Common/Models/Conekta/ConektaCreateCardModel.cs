namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCreateCardModel
    {
        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "token_id")]
        public string TokenId { get; set; }
    }
}
