using System.Collections;
using System.Threading.Tasks;
using Gameplay_System.Helper;
using Gameplay_System.Model;
using UnityEngine;

namespace Gameplay_System.States.Enemy
{
    public class EnemyPatrolState: IState
    {
        private EnemyModel _enemyModel;
        private EnemyAnimationManager _animationManager;
        private Transform _target;
        private bool _enablePatrol;
            
        public void Initialize(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _animationManager = enemyModel.AnimationManager;
        }
        
        public void OnEnter()
        {
            _enemyModel.StartPatrolling();
            _animationManager.StartRun();
        }

        public void UpdateState()
        {
            // patrol the area and chase the target if in range
            _enemyModel.Patrol();
        }

        public void OnExit()
        { 
            _enemyModel.StopPatrolling();
        }
        
    }
}