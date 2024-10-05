using Common.Interfaces;
using Health_System.Initializer.Helper;
using Health_System.Strategy;
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
        [SerializeField] private HealthView _healthView;
        private BattleEquipments _battleEquipments; 

        public HealthModel HealthModel => _healthModel;
        
        public void LaunchTheInitializer(BattleEquipments equipments, IDeathStrategy deathStrategy)
        {
            _battleEquipments = equipments;
            int maxHealth = _healthCalculator.GetMaxHealth(_battleEquipments);
            
            _healthModel.Initialize(maxHealth, deathStrategy);
            InitializeSystem();
        }

        public void InitializeSystem()
        {
            healthController.Initialize(_healthModel, _healthView);
        }

    }
}