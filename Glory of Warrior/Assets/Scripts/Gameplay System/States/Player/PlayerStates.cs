using Zenject;

namespace Gameplay_System.States.Player
{
    public enum UpdateMethod{
        Update,
        FixedUpdate,
        LateUpdate
    }
    public struct PlayerStates
    {
        public IState IdleState { get; private set;}
        public IState RunState { get; private set; }
        public IState AttackState { get; private set; }
        
        [Inject]
        public PlayerStates(
            [Inject(Id = "IdleState")] IState idleState,
            [Inject(Id = "RunState")] IState runState,
            [Inject(Id = "AttackState")] IState attackState)
        {
            IdleState = idleState;
            RunState = runState;
            AttackState = attackState;
        }
    }
}