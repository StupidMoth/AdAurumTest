namespace Game
{
    public interface IQuizCounter
    {
        int CorrectAnswers { get; set; }
        int IncorrectAnswers { get; set; }
        int Score { get; }

        void Reset();
    }
}