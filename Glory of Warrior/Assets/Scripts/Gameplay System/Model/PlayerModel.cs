using Gameplay_System.Helper;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Weapons;
using Health_System;
using Zenject;

namespace Gameplay_System.Model
{
    public class PlayerModel: WarriorModel
    {
        [Inject] private PlayerMovement _playerMovement;
        
        public bool IsMoving { get; private set; }
        
        public override void Initialize(Weapon weapon, HealthModel healthModel, int attackPower, int defensePower)
        {
            base.Initialize(weapon, healthModel, attackPower, defensePower);
            _movement = _playerMovement;
        }
        
        public void SetMovement(bool isMoving)
        {
            IsMoving = isMoving; 
        }
    }
}