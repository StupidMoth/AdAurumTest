using Newtonsoft.Json;

namespace Infrastructure.Serialization
{
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string ToJson<T>(T @object)
        {
            return JsonConvert.SerializeObject(@object, Formatting.Indented);
        }

    }
}