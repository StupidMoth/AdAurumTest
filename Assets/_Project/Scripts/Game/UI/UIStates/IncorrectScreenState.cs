using System.Collections.Generic;

namespace Game.UI
{
    public class IncorrectScreenState : ScreenState
    {
        public IncorrectScreenState(IntermediateScreen screen, List<Screen> allScreens)
            : base(screen, allScreens) { }

        public override void OnEnter()
        {
            ((IntermediateScreen)_screen).ShowIncorrect();
        }
    }
}