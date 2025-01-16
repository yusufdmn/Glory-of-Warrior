using Gameplay_System.Animation_Management;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Helper.Weapons;
using Health_System.Model;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Model
{
    public class PlayerModel: WarriorModel
    {
        private PlayerMovement _playerMovement;
        private PlayerAnimationManager _playerAnimationManager;
        private int _attackParameter;

        
        public bool IsMoving { get; private set; }
        
        [Inject]
        public PlayerModel(PlayerMovement playerMovement, PlayerAnimationManager playerAnimationManager)
        {
            _playerMovement = playerMovement;
            _playerAnimationManager = playerAnimationManager;
        }
        
        public override void Initialize(Weapon weapon, IHealthModel healthModel, int attackPower, int defensePower)
        {
            base.Initialize(weapon, healthModel, attackPower, defensePower);
            _movement = _playerMovement;
            _animationManager = _playerAnimationManager;
            _attackParameter = Animator.StringToHash(weapon.AnimationName);
        }
        
        public void SetMovement(bool isMoving)
        {
            IsMoving = isMoving; 
        }
        
        public override void Attack()
        {
            if(IsAttacking) 
                return;
            
            base.Attack();
            _playerAnimationManager.Attack(_attackParameter);
        }
    }
}