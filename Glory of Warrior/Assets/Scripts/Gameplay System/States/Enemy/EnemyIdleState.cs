using Gameplay_System.Animation_Management;
using Gameplay_System.Model;
using UnityEngine;

namespace Gameplay_System.States.Enemy
{
    public class EnemyIdleState:IState
    {
        private EnemyModel _enemyModel;
        private EnemyAnimationManager _animationManager;
        
        public void Initialize(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _animationManager = enemyModel.AnimationManager;
        }
        
        public void OnEnter()
        {
            _animationManager.StopRun();
        }

        public void UpdateState()
        {
            _enemyModel.WatchTarget();
        }

        public void OnExit()
        {
            _animationManager.StartRun();
        }
    }
}