using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VContainer;
using Infrastructure;
using Infrastructure.Resources;
using Random = UnityEngine.Random;

namespace Game.UI
{
    public class QuestionScreen : Screen
    {
        [SerializeField]
        private Image _background;

        [SerializeField]
        private TMP_Text _question;

        [SerializeField]
        private VerticalLayoutGroup _buttons;

        [SerializeField]
        private QuizButton _buttonPrefab;

        private ISpriteLoader _spriteLoader;
        private GameConfig _gameConfig;


        [Inject]
        public void Construct(ISpriteLoader spriteLoader, GameConfig gameConfig)
        {
            _spriteLoader = spriteLoader;
            _gameConfig = gameConfig;
        }


        public event Action<int> Answered;

        public void SetSlide(ISlide slide)
        {
            var slideInfo = slide.Info;

            _question.text = slideInfo.Question;

            SetBackground(slideInfo);
            DisplayButtons(slideInfo);

            if (_gameConfig.ShuffleAnswers)
            {
                Shuffle(_buttons.transform);
            }

        }

        private void DisplayButtons(ISlideInfo slideInfo)
        {
            var buttons = _buttons.GetComponentsInChildren<QuizButton>();

            foreach (var button in buttons)
            {
                button.Clicked -= OnAnswered;
                button.Destroy();
            }

            for (int index = 0; index < slideInfo.Answers.Count; index++)
            {
                QuizButton button = Instantiate(_buttonPrefab, _buttons.transform);

                Answer answer = slideInfo.Answers[index];

                button.Construct(answer.Text, index);
                button.Clicked += OnAnswered;
            }
        }

        private void SetBackground(ISlideInfo slideInfo)
        {
            var path = Path.Combine(
                Application.streamingAssetsPath,
                _gameConfig.ImagesPath,
                slideInfo.Background);

            if (_spriteLoader.TryLoad(path, out var sprite))
            {
                _background.sprite = sprite;
            }
        }

        public void Shuffle(Transform parent)
        {
            List<int> indexes = new();
            List<Transform> children = new();

            for (int index = 0; index < parent.childCount; index++)
            {
                indexes.Add(index);
                children.Add(parent.GetChild(index));
            }

            foreach (var child in children)
            {
                child.SetSiblingIndex(indexes[Random.Range(0, indexes.Count)]);
            }
        }

        private void OnAnswered(int index)
        {
            Answered?.Invoke(index);
        }
    }
}