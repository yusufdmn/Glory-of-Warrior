using Gameplay_System.Model;
using Gameplay_System.States.Player;
using Gameplay_System.View;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Controller
{
    public class PlayerController: IWarriorController
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private PlayerStates _states; 
        private PlayerStateMachine _playerStateMachine;
        
        public event OnSuccessfulAttackDelegate OnSuccessfulAttack;

        
        [Inject]
        public PlayerController(PlayerView playerView, PlayerStateMachine playerStateMachine, PlayerStates states)
        {
            _playerView = playerView;
            _playerStateMachine = playerStateMachine;
            _states = states;
        }

        
        public void Initialize(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        
            _playerStateMachine.StartMachine(_states.IdleState);
            _playerView.OnAttackButtonClicked += OnAttack;
            _playerView.OnMoveChanged += OnMoveChange;
            //_playerModel.OnAttackStopped += OnReturnToMovement;
            _playerModel.OnSuccessfulAttack += OnTargetHit; 
            _playerModel.OnDeath += OnDeath;
        }

        private void OnTargetHit(GameObject target, int attackPower)
        {
            OnSuccessfulAttack?.Invoke(target, attackPower);
        }

        private void OnAttack()
        {
            _playerModel.Attack();
            //_playerStateMachine.SetState(_states.AttackState);
        }
        
        
        private void OnReturnToMovement()
        {
            if (_playerModel.IsMoving)
                _playerStateMachine.SetState(_states.RunState);
            else
                _playerStateMachine.SetState(_states.IdleState);
        }

        private void OnMoveChange(bool isMoving)
        {
            _playerModel.SetMovement(isMoving);

         //   if (_playerModel.IsAttacking) // if player is attacking, don't allow state change
         //       return;
            
            OnReturnToMovement();
        }
        
        private void OnDeath()
        {
            _playerView.OnDeath();
        }

        ~PlayerController()
        {
            _playerView.OnAttackButtonClicked -= OnAttack;
            _playerView.OnMoveChanged -= OnMoveChange;
            _playerModel.OnAttackStopped -= OnReturnToMovement;
            _playerModel.OnSuccessfulAttack -= OnTargetHit;
            _playerModel.OnDeath -= OnDeath;
        }
        
    }
}