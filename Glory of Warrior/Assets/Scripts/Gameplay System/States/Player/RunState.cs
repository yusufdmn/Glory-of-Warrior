using Gameplay_System.Animation_Management;
using Gameplay_System.Model;
using UnityEngine;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class RunState : IState
    {
        [Inject] private PlayerModel _playerModel;
        [Inject] private PlayerAnimationManager _playerAnimationManager;
        public UpdateMethod UpdateMethod => UpdateMethod.FixedUpdate;

        public void OnEnter()
        {
            _playerAnimationManager.StartRun();
        }

        public void UpdateState()
        {
            _playerModel.Move();
        }

        public void OnExit()
        {
            _playerAnimationManager.StopRun();
        }
    }
}