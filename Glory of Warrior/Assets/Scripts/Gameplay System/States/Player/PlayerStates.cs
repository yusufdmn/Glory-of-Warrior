using Zenject;

namespace Gameplay_System.States.Player
{
    public struct PlayerStates
    {
        [Inject] public IdleState IdleState { get; }
        [Inject] public RunState RunState { get; }
        [Inject] public AttackState AttackState { get; }
    }
}