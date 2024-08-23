using Gameplay_System.Helper;
using Gameplay_System.Weapons;
using Zenject;

namespace Gameplay_System.Model
{
    public class PlayerModel: WarriorModel
    {
        [Inject] private PlayerMovement _PlayerMovement;
        
        public bool IsMoving { get; private set; }
        
        public override void Initialize(IWeapon weapon)
        {
            base.Initialize(weapon);
            _movement = _PlayerMovement;
        }
        
        public void SetMovement(bool isMoving)
        {
            IsMoving = isMoving; 
        }
    }
}