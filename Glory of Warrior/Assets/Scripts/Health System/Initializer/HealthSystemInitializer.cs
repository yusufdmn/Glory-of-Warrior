using System;
using Health_System.Controller;
using Health_System.Initializer.Helper;
using Health_System.Model;
using Health_System.Strategy;
using Health_System.View;
using Helper.Interfaces;
using Inventory_System.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Health_System.Initializer
{
    public class HealthSystemInitializer: MonoBehaviour, ISystemInitializer // it's attached to all warrior game objects 
    {
        private IHealthController _healthController;
        private IHealthModel _healthModel;
        private HealthCalculator _healthCalculator;
        private IHealthView _healthView;
        
        public IHealthModel HealthModel => _healthModel;
        
        [Inject]
        public void Construct(IHealthController healthController, IHealthModel healthModel, HealthCalculator healthCalculator)
        {
            _healthController = healthController;
            _healthModel = healthModel;
            _healthCalculator = healthCalculator;
        }

        public void LaunchTheInitializer(BattleEquipments equipments, IDeathStrategy deathStrategy, int healthMultiplier = 1)
        {
            GetComponentInChildren<Canvas>().transform.GetChild(0).gameObject.SetActive(true); // Activate the health bar
            _healthView = GetComponentInChildren<HealthView>();
            
            int maxHealth = _healthCalculator.GetMaxHealth(equipments, healthMultiplier);
            
            _healthModel.Initialize(maxHealth, deathStrategy);
            _healthView.Initialize(maxHealth);
            InitializeSystem();
        }

        public void InitializeSystem()
        {
            _healthController.Initialize(_healthModel, _healthView);
        }

    }
}