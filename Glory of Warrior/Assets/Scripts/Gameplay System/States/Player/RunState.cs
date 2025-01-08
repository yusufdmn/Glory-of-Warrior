using Gameplay_System.Animation_Management;
using Gameplay_System.Model;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class RunState : IState
    {
        private PlayerModel _playerModel;
        private PlayerAnimationManager _playerAnimationManager;
        public UpdateMethod UpdateMethod => UpdateMethod.FixedUpdate;
        
        [Inject]
        public RunState(PlayerModel playerModel, PlayerAnimationManager playerAnimationManager)
        {
            _playerModel = playerModel;
            _playerAnimationManager = playerAnimationManager;
        }

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