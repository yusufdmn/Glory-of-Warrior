using Gameplay_System.States.Player;

namespace Gameplay_System.States
{
    public interface IState
    {
        UpdateMethod UpdateMethod { get; }
        void OnEnter();
        void UpdateState();
        void OnExit();
    }
}