using Gameplay_System.Animation_Management;
using Gameplay_System.Model;
using Gameplay_System.States.Player;
using UnityEngine;

namespace Gameplay_System.States.Enemy
{
    public class EnemyIdleState: IEnemyState
    {
        private EnemyModel _enemyModel;
        private EnemyAnimationManager _animationManager;
        
        public UpdateMethod UpdateMethod  => UpdateMethod.Update;
        
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