using Unity.Collections;
using Zenject;

namespace Gameplay_System.States.Enemy
{
    public struct EnemyStates
    {
        public IEnemyState PatrolState { get; }
        public IEnemyState ChaseState { get; }
        public IEnemyState AttackState { get; }
        public IEnemyState IdleState { get; }
        
        
        [Inject]
        public EnemyStates(
            [Inject(Id = "patrolState")] IEnemyState patrolState, 
            [Inject(Id = "chaseState")] IEnemyState chaseState, 
            [Inject(Id = "attackState")]IEnemyState attackState, 
            [Inject(Id = "idleState")] IEnemyState idleState)
        {
            PatrolState = patrolState;
            ChaseState = chaseState;
            AttackState = attackState;
            IdleState = idleState;
        }
    }
}