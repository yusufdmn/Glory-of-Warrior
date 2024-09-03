namespace Gameplay_System.States
{
    public interface IState
    {
        void OnEnter();
        void UpdateState();
        void OnExit();
    }
}