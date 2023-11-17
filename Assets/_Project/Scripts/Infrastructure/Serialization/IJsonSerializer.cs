namespace Infrastructure.Serialization
{
    public interface IJsonSerializer
    {
        T FromJson<T>(string json);
        string ToJson<T>(T @object);
    }
}