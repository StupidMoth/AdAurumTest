using Newtonsoft.Json;
using System.Collections.Generic;

namespace Game
{
    public class SlideInfo : ISlideInfo
    {
        [JsonConstructor]
        public SlideInfo(
            [JsonProperty("question")] string question,
            [JsonProperty("answers")] List<Answer> answers,
            [JsonProperty("background")] string background)
        {
            Question = question;
            Answers = answers;
            Background = background;
        }

        [JsonProperty("question")]
        public string Question { get; }

        [JsonProperty("answers")]
        public IReadOnlyList<Answer> Answers { get; }

        [JsonProperty("background")]
        public string Background { get; }
    }

}