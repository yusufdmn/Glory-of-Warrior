using Gameplay_System.Animation_Management;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Helper.Weapons;
using Health_System;
using Zenject;

namespace Gameplay_System.Model
{
    public class PlayerModel: WarriorModel
    {
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private PlayerAnimationManager _playerAnimationManager;
        
        public bool IsMoving { get; private set; }
        
        public override void Initialize(Weapon weapon, HealthModel healthModel, int attackPower, int defensePower)
        {
            base.Initialize(weapon, healthModel, attackPower, defensePower);
            _movement = _playerMovement;
            _animationManager = _playerAnimationManager;
        }
        
        public void SetMovement(bool isMoving)
        {
            IsMoving = isMoving; 
        }
    }
}