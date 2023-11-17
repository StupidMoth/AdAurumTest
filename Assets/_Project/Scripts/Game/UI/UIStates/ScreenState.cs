using System.Collections.Generic;
using Infrastructure.FSM;

namespace Game.UI
{
    public abstract class ScreenState : IState
    {
        protected readonly List<Screen> _allScreens;
        protected readonly Screen _screen;

        public ScreenState(Screen screen, List<Screen> allScreens)
        {
            _screen = screen;
            _allScreens = allScreens;
        }

        public virtual void OnEnter()
        {
            foreach (var screen in _allScreens)
            {
                screen.Hide();
            }

            _screen.Show();
        }
    }
}