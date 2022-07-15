namespace Test.Api.Definition
{
    using Newtonsoft.Json;

    [JsonObject]
    public class WordDefinition
    {
        [JsonProperty]
        public string Word { get; set; }
    }
}
