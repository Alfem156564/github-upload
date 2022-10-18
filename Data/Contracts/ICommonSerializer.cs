namespace Data.Contracts
{
    public interface ICommonSerializer
    {
        string Serialize(object value);

        T? Deserialize<T>(string value);
    }
}
