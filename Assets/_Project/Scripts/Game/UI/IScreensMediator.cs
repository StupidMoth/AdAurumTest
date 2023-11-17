using Infrastructure.FSM;
using System;

namespace Game.UI
{
    public interface IScreensMediator
    {
        event Action<int> Answered;
        event Action GameExitRequested;
        event Action GameRestartRequested;
        event Action GameStartRequested;
        event Action NextAnswerRequested;

        void Enter<TState>() where TState : IState;
        void SetSlide(ISlide slide);
    }
}