using System.Collections.Generic;

namespace Game.UI
{
    public class CorrectScreenState : ScreenState
    {
        public CorrectScreenState(IntermediateScreen screen, List<Screen> allScreens)
            : base(screen, allScreens) { }

        public override void OnEnter()
        {
            ((IntermediateScreen)_screen).ShowCorrect();
        }
    }
}