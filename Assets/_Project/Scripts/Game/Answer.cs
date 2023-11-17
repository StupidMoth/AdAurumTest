using Newtonsoft.Json;

namespace Game
{
    public class Answer : IAnswer
    {
        [JsonConstructor]
        public Answer(
            [JsonProperty("text")] string text,
            [JsonProperty("correct")] bool correct)
        {
            Text = text;
            IsCorrect = correct;
        }

        [JsonProperty("text")]
        public string Text { get; }

        [JsonProperty("correct")]
        public bool IsCorrect { get; }
    }
}