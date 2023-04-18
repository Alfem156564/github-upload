namespace TestAzure.Api.Definition
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CatalogoDestinoDefinition
    {
        [JsonProperty]
        public int? TipoCatalogoDestinoKey { get; set; }

        [JsonProperty]
        public string Descripcion { get; set; }
    }
}
