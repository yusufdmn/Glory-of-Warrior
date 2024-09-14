using Gameplay_System.States;

namespace Gameplay_System.Controller
{
    public interface IStateMachine
    { 
        void StartMachine(IState _initialState);
        void SetState(IState newState);
    }
}