namespace Common.Models.Conekta
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ConektaCreateClienteModel
    {
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "phone")]
        public string Phone { get; set; }
    }
}
