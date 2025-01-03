using Gameplay_System.Controller;
using Gameplay_System.Factory;
using Gameplay_System.Factory.Params;
using Gameplay_System.Gameplay_Management;
using Gameplay_System.Helper;
using Gameplay_System.Helper.Weapons;
using Gameplay_System.Initializers.Helper;
using Gameplay_System.Model;
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
        private HealthSystemInitializer _healthSystemInitializer;

        private PlayerModel _model;
        private PlayerController _controller;
        private IDeathStrategy _playerDeathStrategy;
        private PowerCalculator _powerCalculator;
        private AttackHandler _attackHandler;
        private HealthSystemInitializerFactory _healthSystemFactory;

        
        [Inject]
        public void Construct(HealthSystemInitializerFactory healthSystemFactory, PlayerModel model, PlayerController controller, 
            IDeathStrategy deathStrategy, PowerCalculator powerCalculator, AttackHandler attackHandler)
        {
            _healthSystemFactory = healthSystemFactory;
            _model = model;
            _controller = controller;
            _playerDeathStrategy = deathStrategy;
            _powerCalculator = powerCalculator;
            _attackHandler = attackHandler;
        }
        
        private void Start()
        {
            InitializeSystem();
        }
        
        public void InitializeSystem()
        {
            // Find the player and its equipments
            var player = GameObject.FindWithTag("Player");
            Weapon weapon = player.GetComponentInChildren<Weapon>();
            BattleEquipments equipments = player.GetComponent<Equipments>().EquippedItems;
            
            // Initialize the health system
            HealthSystemInitializerParams healthSystemInitializerParams = new HealthSystemInitializerParams(player, equipments, _playerDeathStrategy, 3);
            _healthSystemInitializer = _healthSystemFactory.Create(healthSystemInitializerParams);
            
            // Calculate the attack and defense power
            int attackPower = _powerCalculator.GetAttackPower(equipments);
            int defensePower = _powerCalculator.GetDefensePower(equipments);
            
            // Initialize the player model and controller
            _model.Initialize(weapon, _healthSystemInitializer.HealthModel, attackPower, defensePower);
            _controller.Initialize(_model);
            
            // Add the player to the attack handler
            _attackHandler.AddWarrior(weapon.transform.root.gameObject, _model, _controller);

        }
    }
}