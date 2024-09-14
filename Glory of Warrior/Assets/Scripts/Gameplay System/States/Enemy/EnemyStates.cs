using Zenject;

namespace Gameplay_System.States.Enemy
{
    public struct EnemyStates
    {
        [Inject] public EnemyPatrolState PatrolState { get; }
        [Inject] public EnemyChaseState ChaseState { get; }
        [Inject] public EnemyAttackState AttackState { get; }
        [Inject] public EnemyIdleState IdleState { get; }
    }
}