using Gameplay_System.Gameplay;
using Gameplay_System.Model;
using Gameplay_System.States.Player;
using Gameplay_System.View;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Controller
{
    public class PlayerController: IWarriorController
    {
        [Inject] private PlayerModel _playerModel;
        [Inject] private PlayerView _playerView;
        [Inject] private StateMachine _stateMachine;
        [Inject] private PlayerStates _states; 

        public event IWarriorController.OnSuccessfulAttackDelegate OnSuccessfulAttack;
        
        public void Initialize()
        {
            
            _stateMachine.Initialize(_states.IdleState);
            _playerView.OnAttackButtonClicked += OnAttack;
            _playerView.OnMoveChanged += OnMoveChange;
            _playerModel.OnAttackStopped += OnReturnToMovement;
            _playerModel.OnSuccessfulAttack += OnTargetHit;
        }

        private void OnTargetHit(GameObject target, int attackPower)
        {
            OnSuccessfulAttack?.Invoke(target, attackPower);
        }

        private void OnAttack()
        {
            _stateMachine.SetState(_states.AttackState);
        }
        
        
        private void OnReturnToMovement()
        {
            if (_playerModel.IsMoving)
                _stateMachine.SetState(_states.RunState);
            else
                _stateMachine.SetState(_states.IdleState);
        }

        private void OnMoveChange(bool isMoving)
        {
            _playerModel.SetMovement(isMoving);

            if (_playerModel.IsAttacking) // if player is attacking, don't allow state change
                return;
            
            OnReturnToMovement();
        }

        ~PlayerController()
        {
            _playerView.OnAttackButtonClicked -= OnAttack;
            _playerView.OnMoveChanged -= OnMoveChange;
            _playerModel.OnAttackStopped -= OnReturnToMovement;
            _playerModel.OnSuccessfulAttack -= OnTargetHit;
        }
        
    }
}