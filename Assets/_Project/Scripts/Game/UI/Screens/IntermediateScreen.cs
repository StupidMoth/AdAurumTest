using System;
using UnityEngine;

namespace Game.UI
{
    public class IntermediateScreen : Screen
    {
        [SerializeField]
        private RectTransform _correctLabel;

        [SerializeField]
        private RectTransform _incorrectLabel;


        public event Action NextAnswerRequested;

        public void Next()
        {
            NextAnswerRequested?.Invoke();
        }

        public void ShowCorrect()
        {
            Show();

            _correctLabel.gameObject.SetActive(true);
            _incorrectLabel.gameObject.SetActive(false);
        }

        public void ShowIncorrect()
        {
            Show();

            _correctLabel.gameObject.SetActive(false);
            _incorrectLabel.gameObject.SetActive(true);
        }
    }
}