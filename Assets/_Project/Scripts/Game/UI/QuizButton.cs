using System;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class QuizButton : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        private int _id;

        public void Construct(string text, int id)
        {
            _id = id;
            _text.text = text;
        }

        public event Action<int> Clicked;

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Click()
        {
            Clicked?.Invoke(_id);
        }

    }
}