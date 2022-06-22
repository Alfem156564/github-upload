namespace Test.Api.Definition
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ErrorDefinition
    {
        [JsonProperty]
        public string Code { get; set; }

        [JsonProperty]
        public string Message { get; set; }
    }
}
