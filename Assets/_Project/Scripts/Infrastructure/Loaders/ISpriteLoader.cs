using UnityEngine;

namespace Infrastructure.Resources
{
    public interface ISpriteLoader
    {
        bool TryLoad(string relativePath, out Sprite output);
    }
}