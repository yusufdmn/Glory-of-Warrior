using System.Collections.Generic;
using Inventory_System.ScriptableObjects;

namespace Health_System.Initializer.Helper
{
    public class HealthCalculator
    {
        public int GetMaxHealth(BattleEquipments battleEquipments)
        {
            int baseHealth = 100;
            int extraHealth = CalculateExtraHealth(battleEquipments);
            int maxHealth = baseHealth + extraHealth;
            return maxHealth;
        }
        
        private int CalculateExtraHealth(BattleEquipments battleEquipments)
        {
            int totalExtraHealth = 0;
            List<Item> shields = battleEquipments.Equipments.FindAll(item => item is ShieldItem);
            List<Item> bodyArmors = battleEquipments.Equipments.FindAll(item => item is BodyArmorItem);

            foreach (ShieldItem shield in shields)
            {
                totalExtraHealth += shield.HealthValue;
            }
            foreach (BodyArmorItem armor in bodyArmors)
            {
                totalExtraHealth += armor.HealthValue;
            }

            return totalExtraHealth;
        }

    }
}