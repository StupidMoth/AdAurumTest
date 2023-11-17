using System;
using System.Collections.Generic;
using UnityEngine;
using Infrastructure.FSM;

namespace Game.UI
{
    public class ScreensMediator : MonoBehaviour, IScreensMediator
    {
        private readonly SimpleStateMachine _stateMachine = new();

        [SerializeField] private MainMenuScreen _mainMenuScreen;
        [SerializeField] private QuestionScreen _questionScreen;
        [SerializeField] private IntermediateScreen _intermediateScreen;
        [SerializeField] private ResultsScreen _resultsScreen;

        public event Action GameStartRequested;
        public event Action GameExitRequested;
        public event Action NextAnswerRequested;
        public event Action GameRestartRequested;
        public event Action<int> Answered;


        private void Awake()
        {
            Subscribe();

            List<Screen> allScreens = new()
            {
                _mainMenuScreen,
                _questionScreen,
                _intermediateScreen,
                _resultsScreen,
            };

            _stateMachine.Add(new MainMenuScreenState(_mainMenuScreen, allScreens));
            _stateMachine.Add(new QuestionScreenState(_questionScreen, allScreens));
            _stateMachine.Add(new CorrectScreenState(_intermediateScreen, allScreens));
            _stateMachine.Add(new IncorrectScreenState(_intermediateScreen, allScreens));
            _stateMachine.Add(new ResultsScreenState(_resultsScreen, allScreens));

        }

        public void Enter<TState>() where TState : IState
        {
            _stateMachine.Enter<TState>();
        }

        public void SetSlide(ISlide slide)
        {
            _questionScreen.SetSlide(slide);
        }

        private void Subscribe()
        {
            _mainMenuScreen.GameStartRequested +=
                () => GameStartRequested?.Invoke();

            _mainMenuScreen.GameExitRequested +=
                () => GameExitRequested?.Invoke();

            _questionScreen.Answered +=
                (index) => Answered?.Invoke(index);

            _intermediateScreen.NextAnswerRequested +=
                () => NextAnswerRequested?.Invoke();

            _resultsScreen.GameRestartRequested +=
                () => GameRestartRequested?.Invoke();

            _resultsScreen.GameExitRequested +=
                () => GameExitRequested?.Invoke();
        }

    }
}