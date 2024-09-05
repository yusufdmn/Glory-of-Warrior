using Gameplay_System.Helper;
using Gameplay_System.Weapons;
using Zenject;

namespace Gameplay_System.Model
{
    public class PlayerModel: WarriorModel
    {
        [Inject] private PlayerMovement _playerMovement;
        
        public bool IsMoving { get; private set; }
        
        public override void Initialize(Weapon weapon)
        {
            base.Initialize(weapon);
            _movement = _playerMovement;
        }
        
        public void SetMovement(bool isMoving)
        {
            IsMoving = isMoving; 
        }
    }
}