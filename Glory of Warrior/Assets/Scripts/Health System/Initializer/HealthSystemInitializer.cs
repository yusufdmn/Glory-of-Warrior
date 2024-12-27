using System;
using Health_System.Initializer.Helper;
using Health_System.Strategy;
using Helper.Interfaces;
using Inventory_System.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Health_System.Initializer
{
    public class HealthSystemInitializer: MonoBehaviour, ISystemInitializer // it's attached to all warrior game objects 
    {
        [Inject] private HealthController healthController;
        [Inject] private HealthModel _healthModel;
        [Inject] private HealthCalculator _healthCalculator;
        private HealthView _healthView;
        
        public HealthModel HealthModel => _healthModel;

        public void LaunchTheInitializer(BattleEquipments equipments, IDeathStrategy deathStrategy, int healthMultiplier = 1)
        {
            GetComponentInChildren<Canvas>().transform.GetChild(0).gameObject.SetActive(true); // Activate the health bar
            _healthView = GetComponentInChildren<HealthView>();
            
            int maxHealth = _healthCalculator.GetMaxHealth(equipments);
            maxHealth *= healthMultiplier;
            
            _healthModel.Initialize(maxHealth, deathStrategy);
            _healthView.Initialize(maxHealth);
            InitializeSystem();
        }

        public void InitializeSystem()
        {
            healthController.Initialize(_healthModel, _healthView);
        }

    }
}