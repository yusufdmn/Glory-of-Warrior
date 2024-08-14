using Gameplay_System.Player.Model;
using Gameplay_System.Player.View;
using Zenject;

namespace Gameplay_System.Player.Controller
{
    public class PlayerController
    {
        [Inject] private PlayerModel _playerModel;
        [Inject] private PlayerView _playerView;
        [Inject] private PlayerStateMachine _stateMachine;

        public void Initialize()
        {
            _playerView.OnAttackButtonClicked += OnAttack;
            _playerView.OnMoveChanged += OnMoveChange;
            _playerModel.OnAttackStopped += OnReturnToMovement;
        }

        private void OnAttack()
        {
            _stateMachine.SetState(_stateMachine.AttackState);
        }

        private void OnReturnToMovement()
        {
            if (_playerModel.IsMoving)
                _stateMachine.SetState(_stateMachine.RunState);
            else
                _stateMachine.SetState(_stateMachine.IdleState);
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
        }
        
    }
}