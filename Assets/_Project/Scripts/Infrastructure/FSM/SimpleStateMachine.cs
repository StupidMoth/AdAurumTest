using System.Collections.Generic;
using System;

namespace Infrastructure.FSM
{
    public class SimpleStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _availableStates = new();

        public IState Current { get; private set; }


        public void Add(IState state)
        {
            Type stateType = state.GetType();

            if (!_availableStates.ContainsKey(stateType))
            {
                _availableStates.Add(stateType, state);
            }
        }

        public void Enter<TState>() where TState : IState
        {
            if (!_availableStates.ContainsKey(typeof(TState))) return;

            Current = _availableStates[typeof(TState)];
            Current.OnEnter();
        }

    }
}