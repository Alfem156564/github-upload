namespace Data.Helper
{
    using Data.Contracts;
    using Newtonsoft.Json;

    public class CommonJsonSerializer : ICommonSerializer
    {
        public string Serialize(object value) => JsonConvert.SerializeObject(value);

        public T? Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value);
    }
}
