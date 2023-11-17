namespace Game
{
    public interface IAnswer
    {
        bool IsCorrect { get; }
        string Text { get; }
    }
}