using System;
using Gameplay_System.Model;
using Gameplay_System.States.Enemy;
using Unity.VisualScripting;
using UnityEngine;
using IState = Gameplay_System.States.IState;

namespace Gameplay_System.Controller
{
    public class EnemyStateMachine: MonoBehaviour, IStateMachine
    {
        private IState _currentState;

        public void Initialize(IState initialState, EnemyModel enemyModel, EnemyStates enemyStates)
        {
            enemyStates.PatrolState.Initialize(enemyModel);
            enemyStates.ChaseState.Initialize(enemyModel);
            enemyStates.AttackState.Initialize(enemyModel);
            enemyStates.IdleState.Initialize(enemyModel);
            StartMachine(initialState);
        }
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