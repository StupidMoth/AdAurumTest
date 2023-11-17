using System.Collections.Generic;

namespace Game
{
    public class Slide : ISlide
    {
        private Dictionary<int, bool> _correctnessTable = new();

        public Slide(ISlideInfo info)
        {
            Info = info;

            for (int index = 0; index < info.Answers.Count; index++)
            {
                _correctnessTable[index] = info.Answers[index].IsCorrect;
            }
        }

        public ISlideInfo Info { get; init; }

        public bool IsCorrectAnswer(int index)
        {
            if (!_correctnessTable.ContainsKey(index))
            {
                return false;
            }

            return _correctnessTable[index];
        }
    }
}