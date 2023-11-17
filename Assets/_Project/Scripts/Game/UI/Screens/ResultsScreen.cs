using System;
using UnityEngine;
using TMPro;
using VContainer;

namespace Game.UI
{
    public class ResultsScreen : Screen
    {
        [SerializeField]
        private TMP_Text _resultLabel;

        private IQuizCounter _quizCounter;

        [Inject]
        public void Construct(IQuizCounter quizCounter)
        {
            _quizCounter = quizCounter;
        }

        public event Action GameRestartRequested;
        public event Action GameExitRequested;


        public override void Show()
        {
            base.Show();

            _resultLabel.text = _quizCounter.Score.ToString();
        }

        public void RestartGame()
        {
            GameRestartRequested?.Invoke();
        }

        public void ExitGame()
        {
            GameExitRequested?.Invoke();
        }
    }
}