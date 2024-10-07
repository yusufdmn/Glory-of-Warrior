using Common.Interfaces;
using Gameplay_System.Animation_Management;
using Gameplay_System.Controller;
using Gameplay_System.Gameplay_Management;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Initializers.Helper;
using Gameplay_System.Model;
using Gameplay_System.View;
using Gameplay_System.Weapons;
using Health_System.Initializer;
using Health_System.Strategy;
using Inventory_System.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Initializers
{
    public class EnemySystemInitializer : MonoBehaviour, ISystemInitializer // Attached to enemy GameObjects
    {
        [Inject] private EnemyModel _model;
        [Inject] private EnemyController _controller;
        [Inject] private PowerCalculator _powerCalculator;
        [Inject] private AttackHandler _attackHandler;
        [Inject] private EnemyDeathStrategy _enemyDeathStrategy;

        [SerializeField] private GameObject _enemy;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private HealthSystemInitializer _healthSystemInitializer;
        [SerializeField] private BattleEquipments _equipments;
        private void Start()
        {
            InitializeSystem();
        }

        public void InitializeSystem()
        { 
            int attackPower = _powerCalculator.GetAttackPower(_equipments);
            int defensePower = _powerCalculator.GetDefensePower(_equipments);
            _healthSystemInitializer.LaunchTheInitializer(_equipments, _enemyDeathStrategy);
                
            _model.Initialize(_weapon, _enemy.GetComponent<EnemyAnimationManager>(), _healthSystemInitializer.HealthModel, 
                attackPower, defensePower);
            _model.AddMovement(_enemy.GetComponent<EnemyMovement>());
            _controller.Initialize(_model, _enemy.GetComponent<EnemyView>(), _enemy.GetComponent<EnemyStateMachine>());
            _attackHandler.AddWarrior(_enemy, _model, _controller);

        }
    }
}