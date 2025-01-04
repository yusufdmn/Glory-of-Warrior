using Health_System.Strategy;
using Inventory_System.ScriptableObjects;
using UnityEngine;

namespace Gameplay_System.Factory.Params
{
    public struct HealthSystemInitializerParams {
        public GameObject Target { get; }
        public BattleEquipments Equipments { get; }
        public IDeathStrategy DeathStrategy { get; }
        public int HealthMultiplier { get; }

        public HealthSystemInitializerParams(GameObject target, BattleEquipments equipments, 
            IDeathStrategy deathStrategy, int healthMultiplier)
        {
            Target = target;
            Equipments = equipments;
            DeathStrategy = deathStrategy;
            HealthMultiplier = healthMultiplier;
        }
        
    }
}