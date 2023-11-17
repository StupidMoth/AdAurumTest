namespace Infrastructure.FSM
{
    public interface IStateMachine
    {
        IState Current { get; }

        void Enter<TState>() where TState : IState;
        void Add(IState state);
    }
}