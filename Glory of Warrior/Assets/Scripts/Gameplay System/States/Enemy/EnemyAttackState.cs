using System.Collections;
using System.Threading.Tasks;
using Gameplay_System.Animation_Management;
using Gameplay_System.Model;
using Gameplay_System.States.Player;
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
        
        public UpdateMethod UpdateMethod  => UpdateMethod.Update;
        
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
            
            _animationManager.StopRun();
            _animationManager.Attack(_attackParameter);
            _enemyModel.Attack();
        }

        public void UpdateState()
        {
            _enemyModel.WatchTarget();

            if (!_hasAnimationStarted) // if the attack animation hasn't started yet
            {
                CheckAnimationStart();
                return;
            }

            if (_animationManager.GetCurrentState().IsName(_attackAnimationName)) // if the attack animation is still playing
                return;
            
            _enemyModel.StopAttack();
        }

        public void OnExit()
        {
            _hasAnimationStarted = false;
        }
        
        
        private void CheckAnimationStart() 
        {
            if (_animationManager.GetCurrentState().IsTag("Attack"))
            {
                _hasAnimationStarted = true;
            }
        }
    }
}