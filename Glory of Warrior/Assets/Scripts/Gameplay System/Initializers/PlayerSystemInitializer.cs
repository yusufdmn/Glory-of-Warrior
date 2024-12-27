using Gameplay_System.Animation_Management;
using Gameplay_System.Controller;
using Gameplay_System.Gameplay_Management;
using Gameplay_System.Helper;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Helper.Weapons;
using Gameplay_System.Initializers.Helper;
using Gameplay_System.Model;
using Gameplay_System.View;
using Health_System.Initializer;
using Health_System.Strategy;
using Helper.Interfaces;
using Inventory_System.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Initializers
{
    public class PlayerSystemInitializer: MonoBehaviour, ISystemInitializer  // Attached to an empty GameObject
    {
        [Inject] private DiContainer _container;
        //MVC Variables
        [Inject] private PlayerModel _model;
        [Inject] private PlayerView _view;
        [Inject] private PlayerController _controller;
        //Other Systems
        [Inject] private PlayerAnimationManager playerAnimationManager;
        [Inject] private PlayerStateMachine playerStateMachine;
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private PowerCalculator _powerCalculator;
        [Inject] private AttackHandler _attackHandler; 
        [Inject] private PlayerDeathStrategy _playerDeathStrategy;
        private HealthSystemInitializer _healthSystemInitializer;
        
        private void Start()
        {
            InitializeSystem();
        }
        
        public void InitializeSystem()
        {
            Weapon weapon = GameObject.FindWithTag("Player").GetComponentInChildren<Weapon>();
            BattleEquipments equipments = GameObject.FindWithTag("Player").GetComponent<Equipments>().EquippedItems;
            
            _healthSystemInitializer = GameObject.FindWithTag("Player").AddComponent<HealthSystemInitializer>();
            _container.Inject(_healthSystemInitializer);
            _healthSystemInitializer.LaunchTheInitializer(equipments, _playerDeathStrategy, 3);
            
            int attackPower = _powerCalculator.GetAttackPower(equipments);
            int defensePower = _powerCalculator.GetDefensePower(equipments);
            
            _model.Initialize(weapon, _healthSystemInitializer.HealthModel, attackPower, defensePower);
            _controller.Initialize();
            _attackHandler.AddWarrior(weapon.transform.root.gameObject, _model, _controller);

        }
    }
}