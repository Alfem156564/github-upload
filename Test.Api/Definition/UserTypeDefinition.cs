namespace Test.Api.Definition
{
    using Newtonsoft.Json;

    [JsonObject]
    public class UserTypeDefinition
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
