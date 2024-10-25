using Gameplay_System.Animation_Management;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Helper.Weapons;
using Health_System;
using UnityEngine;

namespace Gameplay_System.Model
{
    public abstract class WarriorModel
    {
        internal HealthModel _healthModel;
        protected IMovement _movement;
        protected IAnimationManager _animationManager;

        public delegate void OnSuccessfulAttackDelegate(GameObject target, int attackPower);
        public event OnSuccessfulAttackDelegate OnSuccessfulAttack;
        public delegate void OnAttackStoppedDelegate();
        public event OnAttackStoppedDelegate OnAttackStopped; 
        public delegate void OnDeathDelegate();
        public event OnDeathDelegate OnDeath;
        

        public Weapon AttachedWeapon { get; private set; }
        public bool IsAttacking { get; private set; }
        public int AttackPower { get; private set; }
        public int DefensePower { get; private set; }
        
        
        public virtual void Initialize(Weapon weapon, HealthModel healthModel, int attackPower, int defensePower)
        {
            _healthModel = healthModel;
            AttackPower = attackPower;
            DefensePower = defensePower;
            AttachedWeapon = weapon;
            AttachedWeapon.OnSuccessfulAttack += OnHitTarget;
            healthModel.OnDeath += Die;
        }

        public void OnHitTarget(GameObject target) // when this warrior's weapon hits the target
        {
            OnSuccessfulAttack?.Invoke(target, AttackPower);
        }
        
        public void TakeDamage(int damage)
        {
            _healthModel.DecreaseHealth(damage);
        }
        
        public void Move()
        {
            _movement.Move(); 
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
        
        private void Die()
        {
            OnDeath?.Invoke();
            _animationManager.Die();
        }
        
        ~WarriorModel(){
            AttachedWeapon.OnSuccessfulAttack -= OnHitTarget;
            _healthModel.OnDeath -= Die;
        }
    }
       
}

