using UnityEngine;

namespace Infrastructure
{
    [CreateAssetMenu(fileName = "Config", menuName = "Configs/Game Config", order = 1)]
    public class GameConfig : ScriptableObject
    {
        [Header(".../StreamingAssets/")]
        public string ImagesPath;

        [Header(".../StreamingAssets/")]
        public string JsonPath;

        public string JsonFileName;

        [Header("Options: ")]
        public bool ShuffleSlides;
        public bool ShuffleAnswers;
    }
}