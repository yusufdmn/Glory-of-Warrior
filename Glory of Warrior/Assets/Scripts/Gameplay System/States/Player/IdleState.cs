using UnityEngine;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class IdleState: IState
    {
        [Inject] private AnimationManager _animationManager;

        public void OnEnter()
        {
            _animationManager.StopRun();
        }

        public void UpdateState()
        {
            // increase energy
        }

        public void OnExit()
        {
            // stop increasing energy
        }

    }
}