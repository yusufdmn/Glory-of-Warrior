using Gameplay_System.Model;
using Gameplay_System.States.Enemy;
using Gameplay_System.View;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Controller
{
    public class EnemyController: IWarriorController
    {
        private EnemyModel _model;
        private EnemyView _view;
        private EnemyStateMachine _stateMachine;
        [Inject] private EnemyStates _states; 
        
        public event IWarriorController.OnSuccessfulAttackDelegate OnSuccessfulAttack;
        
        public void Initialize(EnemyModel enemyModel, EnemyView enemyView, EnemyStateMachine enemyStateMachine)
        {
            _model = enemyModel;
            _view = enemyView;
            _stateMachine = enemyStateMachine;
            _stateMachine.Initialize(_states.PatrolState, _model, _states);
            
            _view.OnAttackTargetUpdated += OnAttackTargetUpdate;
            _view.OnChaseTargetUpdated += OnChaseTargetUpdate;
            _model.OnSuccessfulAttack += OnTargetHit;
            _model.OnAttackStopped += OnAfterAttack;
            _model.OnDeath += OnDeath;
        }
        
        private void OnChaseTargetUpdate(Transform target)
        {
            _model.UpdateTarget(target);

            if(_model.IsAttacking)  // if enemy is attacking, don't allow state change
                return;
            
            PatrolOrChase(target);
        }

        private void PatrolOrChase(Transform target)
        {
            if (!target)  // if target is null, go back to patrol state
            {
                _stateMachine.SetState(_states.PatrolState);
            }
            else
            {
                _stateMachine.SetState(_states.ChaseState);
            }
        }

        private void OnAttackTargetUpdate(Transform target)
        {
            if (!target) // just extra control to make sure there is target to attack
                return;
            
            _model.UpdateTarget(target);
            _stateMachine.SetState(_states.AttackState);
        }
     
        private void OnAfterAttack()
        {
            _stateMachine.SetState(_states.IdleState);
        }
        
        
        private void OnTargetHit(GameObject target, int attackPower)
        {
            OnSuccessfulAttack?.Invoke(target, attackPower);
        }

        private void OnDeath()
        {
            _stateMachine.StopMachine();
            _model.AnimationManager.Die();
            _view.OnDeath();
        }
        
        ~EnemyController()
        {
            _view.OnAttackTargetUpdated -= OnAttackTargetUpdate;
            _view.OnChaseTargetUpdated -= OnChaseTargetUpdate;
            _model.OnSuccessfulAttack -= OnTargetHit;
            _model.OnAttackStopped -= OnAfterAttack; 
            _model.OnDeath -= OnDeath;
        }
    }
}