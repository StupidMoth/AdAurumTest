using UnityEngine;
using System.Collections.Generic;
using VContainer;
using System.Linq;
using System;
using Infrastructure;
using Infrastructure.Resources;
using Game.UI;
using VContainer.Unity;

namespace Game
{
    public class QuizRunner : IInitializable, IStartable
    {
        private Queue<ISlideInfo> _orderedSlides;
        private ISlideInfo[] _slides;
        private ISlide _currentSlide;

        private GameConfig _gameConfig;
        private IDataLoader _loader;
        private IQuizCounter _quizCounter;
        private IScreensMediator _screens;

        [Inject]
        public void Construct(
            IDataLoader loader, 
            IQuizCounter quizCounter, 
            GameConfig gameConfig,
            IScreensMediator screensMediator)
        {
            _loader = loader;
            _quizCounter = quizCounter;
            _gameConfig = gameConfig;
            _screens = screensMediator;
        }

        public void Initialize()
        {
            _screens.GameStartRequested += OnGameStartRequested;
            _screens.GameExitRequested += OnGameExitRequested;
            _screens.Answered += OnAnswered;
            _screens.NextAnswerRequested += OnNextAnswerRequested;
            _screens.GameRestartRequested += OnGameRestartRequested;
        }

        public void Start()
        {

            if (_loader.TryLoad(out SlideInfo[] slideInfos))
            {
                _slides = slideInfos;

                Restart();

                return;
            }

            Debug.LogError("Не удалось загрузить набор слайдов");
        }

        private void Restart()
        {
            _quizCounter.Reset();

            _screens.Enter<MainMenuScreenState>();

            if (_gameConfig.ShuffleSlides)
            {
                _slides = _slides
                    .OrderBy(e => Guid.NewGuid())
                    .ToArray();
            }

            _orderedSlides = new(_slides);
        }

        private void NextAnswer()
        {
            if (_orderedSlides.Count > 0)
            {
                _currentSlide = new Slide(_orderedSlides.Dequeue());
                _screens.Enter<QuestionScreenState>();
                _screens.SetSlide(_currentSlide);

                return;
            }

            _screens.Enter<ResultsScreenState>();
        }

        private void OnAnswered(int index)
        {
            if (_currentSlide is null) return;

            if (_currentSlide.IsCorrectAnswer(index))
            {
                _screens.Enter<CorrectScreenState>();
                _quizCounter.CorrectAnswers++;

                return;
            }

            _screens.Enter<IncorrectScreenState>();
            _quizCounter.IncorrectAnswers++;
        }

        private void OnGameExitRequested()
        {
            Application.Quit();
        }

        private void OnNextAnswerRequested()
        {
            NextAnswer();
        }

        private void OnGameStartRequested()
        {
            _screens.Enter<QuestionScreenState>();
            NextAnswer();
        }

        private void OnGameRestartRequested()
        {
            Restart();
        }

    }
}