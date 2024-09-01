using System.Threading.Tasks;
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
        [Inject] private AnimationManager _animationManager;

        public void Initialize()
        {
            _attackAnimationName = _playerModel.Weapon.AnimationName;
            _attackParameter = Animator.StringToHash(_attackAnimationName);
        }
        
        public void OnEnter()
        {
            if (_attackAnimationName == null)
            {
                Initialize();
            }
            
            _animationManager.Attack(_attackParameter);
            _playerModel.Attack();
            CheckAnimationStartAsync();
        }

        public void UpdateState()
        {
            if(!_hasAnimationStarted)
                return;

            if (_animationManager.GetCurrentState().IsName(_attackAnimationName)) 
                return;
            
            _playerModel.StopAttack();
        }

        public void OnExit()
        {
            _hasAnimationStarted = false;
        }
        
        
        
        private async void CheckAnimationStartAsync()
        {
            while (!_hasAnimationStarted)
            {
                await Task.Delay(10); 

                if (_animationManager.GetCurrentState().IsTag("Attack"))
                {
                    _hasAnimationStarted = true;
                }
            }

        }
    }
}