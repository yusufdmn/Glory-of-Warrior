using Gameplay_System.Animation_Management;
using UnityEngine;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class IdleState: IState
    {
        [Inject] private PlayerAnimationManager _playerAnimationManager;

        public void OnEnter()
        {
            _playerAnimationManager.StopRun();
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