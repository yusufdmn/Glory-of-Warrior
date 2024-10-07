using Gameplay_System.Model;
using Gameplay_System.States;
using Gameplay_System.States.Enemy;
using UnityEngine;

namespace Gameplay_System.Controller
{
    public class EnemyStateMachine: MonoBehaviour, IStateMachine
    {
        private IState _currentState;
        private bool _isEnabled;

        public void Initialize(IState initialState, EnemyModel enemyModel, EnemyStates enemyStates)
        {
            enemyStates.PatrolState.Initialize(enemyModel);
            enemyStates.ChaseState.Initialize(enemyModel);
            enemyStates.AttackState.Initialize(enemyModel);
            enemyStates.IdleState.Initialize(enemyModel);
            StartMachine(initialState);
        }
        private void Update()
        {
            if (!_isEnabled)
                return;
            _currentState?.UpdateState();
        }
        
        public void StartMachine(IState initialState)
        {
            _isEnabled = true;
            SetState(initialState);
        }
        
        public void StopMachine()
        {
            _isEnabled = false;
            _currentState?.OnExit();
            _currentState = null;
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