using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace Infrastructure.Resources
{
    public class SpriteLoader : ISpriteLoader
    {
        private readonly Vector2 _pivot = new(.5f, .5f);
        private readonly Dictionary<string, Sprite> _cache = new();

        public bool TryLoad(string relativePath, out Sprite output)
        {
            var absolutePath = Path.Combine(Application.streamingAssetsPath, relativePath);

            if (_cache.ContainsKey(absolutePath))
            {
                output = _cache[absolutePath];
                return true;
            }

            if (File.Exists(absolutePath))
            {
                Texture2D texture = new(0, 0);
                byte[] imageBytes = File.ReadAllBytes(absolutePath);

                ImageConversion.LoadImage(texture, imageBytes);

                var sprite = Sprite.Create(
                    texture, new Rect(0, 0, texture.width, texture.height), _pivot);

                _cache[absolutePath] = sprite;

                output = sprite;
                return true;
            }

            output = default;
            return false;
        }

    }
}