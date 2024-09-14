using Gameplay_System.States;
using UnityEngine;

namespace Gameplay_System.Controller
{
    public class PlayerStateMachine: MonoBehaviour, IStateMachine
    {
        private IState _currentState;
        
        public void StartMachine(IState initialState)
        {
            SetState(initialState);
        }

        private void Update()
        {
            _currentState?.UpdateState();
        }
        
        public void SetState(IState newState)
        {
            if (_currentState == newState) // Don't allow re-entering the current state
                return;
            
            _currentState?.OnExit();
            newState.OnEnter();
            _currentState = newState;
        }
    }
}