using Gameplay_System.Weapons;
using Zenject;

namespace Gameplay_System.Player.Model
{
    public class PlayerModel
    {
        private IWeapon Weapon;
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private AnimationManager _animationManager;

        public delegate void OnAttackStoppedDelegate();
        public event OnAttackStoppedDelegate OnAttackStopped; 
        
        public bool IsMoving { get; private set; }
        public bool IsAttacking { get; private set; }

        public void Initialize(IWeapon weapon)
        {
            Weapon = weapon;
        }
        
        public void Attack()
        {
            IsAttacking = true;
            Weapon.Attack();
        }

        public void Move()
        {
            _playerMovement.Move(); 
        }

        public void StopAttack()
        {
            IsAttacking = false;
            OnAttackStopped?.Invoke();
        }

        public void SetMovement(bool isMoving)
        {
            IsMoving = isMoving; 
        }
    }
}