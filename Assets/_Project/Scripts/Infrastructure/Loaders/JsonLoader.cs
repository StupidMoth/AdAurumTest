using UnityEngine;
using System.IO;
using Infrastructure;
using Infrastructure.Serialization;

namespace Infrastructure.Resources
{
    public class JsonLoader : IDataLoader
    {
        private readonly string _path;
        private readonly IJsonSerializer _serializer;

        public JsonLoader(IJsonSerializer serializer, GameConfig gameConfig)
        {
            _serializer = serializer;

            _path = Path.Combine(
                Application.streamingAssetsPath,
                gameConfig.JsonPath,
                gameConfig.JsonFileName);
        }

        public bool TryLoad<T>(out T output)
        {
            if (File.Exists(_path))
            {
                string fileText = File.ReadAllText(_path);

                output = _serializer.FromJson<T>(fileText);
                return true;
            }

            output = default;
            return false;
        }
    }
}