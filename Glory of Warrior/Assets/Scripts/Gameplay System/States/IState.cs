namespace Gameplay_System.States
{
    public interface IState
    {
        public void OnEnter();
        public void UpdateState();
        public void OnExit();
    }
}