namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCheckoutModel
    {
        [JsonProperty(propertyName: "returns_control_on")]
        public string ReturnsControlOn { get; set; }
    }
}
