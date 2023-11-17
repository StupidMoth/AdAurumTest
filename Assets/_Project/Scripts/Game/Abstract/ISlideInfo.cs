using System.Collections.Generic;

namespace Game
{
    public interface ISlideInfo
    {
        IReadOnlyList<Answer> Answers { get; }
        string Background { get; }
        string Question { get; }
    }
}