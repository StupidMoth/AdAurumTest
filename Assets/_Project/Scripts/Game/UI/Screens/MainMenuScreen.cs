using System;

namespace Game.UI
{
    public class MainMenuScreen : Screen
    {
        public event Action GameStartRequested;
        public event Action GameExitRequested;

        public void StartGame()
        {
            GameStartRequested?.Invoke();
        }

        public void ExitGame()
        {
            GameExitRequested?.Invoke();
        }
    }
}