namespace Game
{
    public class QuizCounter : IQuizCounter
    {
        public int Score => CorrectAnswers;
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }

        public void Reset()
        {
            CorrectAnswers = 0;
            IncorrectAnswers = 0;
        }
    }
}