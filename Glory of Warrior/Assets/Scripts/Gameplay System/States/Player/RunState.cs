using Gameplay_System.Model;
using UnityEngine;
using Zenject;

namespace Gameplay_System.States.Player
{
    public class RunState : IState
    {
        [Inject] private PlayerModel _playerModel;
        [Inject] private AnimationManager _animationManager;

        public void OnEnter()
        {
            _animationManager.StartRun();
        }

        public void UpdateState()
        {
            // decrease energy 
            _playerModel.Move();
        }

        public void OnExit()
        {
            // stop decreasing energy 
        }
    }
}