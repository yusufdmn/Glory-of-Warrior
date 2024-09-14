using System.Threading.Tasks;
using Gameplay_System.Model;
using UnityEngine;

namespace Gameplay_System.States.Enemy
{
    public class EnemyAttackState: IState
    {
        private bool _hasAnimationStarted;
        private bool _hasInitialized;
        private string _attackAnimationName;
        private int _attackParameter;
        private EnemyModel _enemyModel;
        private EnemyAnimationManager _animationManager;
        
        public void Initialize(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _animationManager = enemyModel.AnimationManager;
            
            _attackAnimationName = _enemyModel.AttachedWeapon.AnimationName;
            _attackParameter = Animator.StringToHash(_attackAnimationName); 
            
            _hasInitialized = true;
        }

        public void OnEnter()
        {
            if(!_hasInitialized)
                return;
            
            _animationManager.Attack(_attackParameter);
            _enemyModel.Attack();
            CheckAnimationStartAsync();
        }

        public void UpdateState()
        {
            if(!_hasAnimationStarted)
                return;

            if (_animationManager.GetCurrentState().IsName(_attackAnimationName)) 
                return;
            
            _enemyModel.StopAttack();
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