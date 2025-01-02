using Gameplay_System.Animation_Management;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Helper.Weapons;
using Health_System;
using Health_System.Model;
using UnityEngine;

namespace Gameplay_System.Model
{
    public class EnemyModel: WarriorModel
    {
        private EnemyMovement _enemyMovement;
        public EnemyAnimationManager AnimationManager { get; private set; }

        public void Initialize(Weapon weapon, EnemyAnimationManager animationManager, 
            IHealthModel healthModel, int attackPower, int defensePower)
        {
            base.Initialize(weapon, healthModel, attackPower, defensePower);
            AnimationManager = animationManager;
            _animationManager = AnimationManager;
        }

        public void AddMovement(EnemyMovement enemyMovement)
        {
            _enemyMovement = enemyMovement;
            _movement = enemyMovement;
        }
        
        public void UpdateTarget(Transform target)
        { 
            _enemyMovement.SetTarget(target);
        }
        
        public void StartPatrolling()
        {
            _enemyMovement.StartMovement();
            _enemyMovement.SetPatrolPoint();
        }
        public void Patrol()
        {
            _enemyMovement.Patrol();
        }
        public void StopPatrolling()
        {
            _enemyMovement.ResetPatrolPoint();
        }

        public void StartChasing()
        {
            _enemyMovement.StartMovement();
        }
        public void Chase()
        {
            base.Move();
        }
        public void StopChasing()
        {
            _enemyMovement.StopMovement();
        }

        public void WatchTarget()
        {
            if (!_enemyMovement.HasTarget())
                return;
            _enemyMovement.RotateTowardsTarget();
        }

        
    }
}