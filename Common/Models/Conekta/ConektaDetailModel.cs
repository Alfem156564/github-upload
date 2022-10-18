namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaDetailModel
    {
        [JsonProperty(propertyName: "debug_message")]
        public string DebugMessage { get; set; }

        [JsonProperty(propertyName: "message")]
        public string Message { get; set; }

        [JsonProperty(propertyName: "param")]
        public string Param { get; set; }

        [JsonProperty(propertyName: "code")]
        public string Code { get; set; }
    }
}
