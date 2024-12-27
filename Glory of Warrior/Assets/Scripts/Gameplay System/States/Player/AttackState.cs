using System.Collections;
using System.Threading.Tasks;
using Gameplay_System.Animation_Management;
using Gameplay_System.Model;
using UnityEngine;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class AttackState: IState
    {
        private bool _hasAnimationStarted;
        private string _attackAnimationName;
        private int _attackParameter;
        
        [Inject] private PlayerModel _playerModel;
        [Inject] private PlayerAnimationManager _playerAnimationManager;

        public UpdateMethod UpdateMethod  => UpdateMethod.Update;

        private void Initialize()
        {
            _attackAnimationName = _playerModel.AttachedWeapon.AnimationName;
            _attackParameter = Animator.StringToHash(_attackAnimationName);
        }
        
        public void OnEnter()
        {
            if (_attackAnimationName == null)
            {
                Initialize();
            }
            
            _playerAnimationManager.Attack(_attackParameter);
            _playerModel.Attack();
        }

        public void UpdateState()
        {
            if (!_hasAnimationStarted) // if the attack animation hasn't started yet
            {
                CheckAnimationStart();
                return;
            }

            if (_playerAnimationManager.GetCurrentState().IsName(_attackAnimationName)) // if the attack animation is still playing
                return;
            
            _playerModel.StopAttack();
        }

        public void OnExit()
        {
            _hasAnimationStarted = false;
        }
        
        
        private void CheckAnimationStart() 
        {
            if (_playerAnimationManager.GetCurrentState().IsTag("Attack"))
            {
                _hasAnimationStarted = true;
            }
        }
    }
}