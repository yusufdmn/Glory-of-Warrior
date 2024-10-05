using Gameplay_System.Animation_Management;
using Gameplay_System.Model;

namespace Gameplay_System.States.Enemy
{
    public class EnemyChaseState: IState
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
            _animationManager.StartRun();
            _enemyModel.StartChasing();
        }

        public void UpdateState()
        {
            _enemyModel.Chase();
            // follow the target and attack if in range
        }

        public void OnExit()
        {
            _enemyModel.StopChasing();
        }
    }
}