using Gameplay_System.Helper;
using Gameplay_System.Weapons;
using Health_System;
using UnityEngine;

namespace Gameplay_System.Model
{
    public abstract class WarriorModel
    {
        private HealthModel _healthModel;
        private int _attackPower;
        
        protected IMovement _movement;
        
        public Weapon AttachedWeapon { get; private set; }

        public delegate void OnSuccessfulAttackDelegate(GameObject target, int attackPower);
        public event OnSuccessfulAttackDelegate OnSuccessfulAttack;
        
        public delegate void OnAttackStoppedDelegate();
        public event OnAttackStoppedDelegate OnAttackStopped; 

        public bool IsAttacking { get; private set; }

        public virtual void Initialize(Weapon weapon)
        {
            AttachedWeapon = weapon;
            AttachedWeapon.OnSuccessfulAttack += OnHitTarget;
        }
        
        public void PrepareForBattle(HealthModel healthModel, int attackPower)
        {
            _healthModel = healthModel;
            _attackPower = attackPower;
        }

        public void OnHitTarget(GameObject target)
        {
            int attackPower = 10; // currently temporary, it will be calculated
            OnSuccessfulAttack?.Invoke(target, attackPower);
        }
        
        public void Move()
        {
            _movement.Move(); 
        }
        
        public void DealWithAttack(int attackPower)
        {
            
        }

        public void Attack()
        {
            IsAttacking = true;
            AttachedWeapon.Attack();
        }

        public void StopAttack()
        {
            IsAttacking = false;
            AttachedWeapon.StopAttack();
            OnAttackStopped?.Invoke();
        }
        
    }
}

