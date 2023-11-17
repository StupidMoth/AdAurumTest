namespace Game
{
    public interface ISlide
    {
        ISlideInfo Info { get; }
        bool IsCorrectAnswer(int index);
    }
}