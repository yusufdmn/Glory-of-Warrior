using System.Collections.Generic;
using Inventory_System.ScriptableObjects;

namespace Gameplay_System.Initializers.Helper
{
    public class PowerCalculator
    {
        public int GetAttackPower(BattleEquipments battleEquipments)
        {
            int baseAttackPower = 10;
            int extraAttackPower = CalculateExtraAttackPower(battleEquipments);
            int attackPower = baseAttackPower + extraAttackPower;
            return attackPower;
        }
        
        public int GetDefensePower(BattleEquipments battleEquipments)
        {
            int baseDefensePower = 5;
            int extraDefensePower = CalculateExtraDefensePower(battleEquipments);
            int defensePower = baseDefensePower + extraDefensePower;
            return defensePower;
        }
        
        private int CalculateExtraAttackPower(BattleEquipments battleEquipments)
        {
            int totalExtraAttackPower = 0;
            Item weapon = battleEquipments.Equipments.Find(item => item is WeaponItem);
            totalExtraAttackPower += ((WeaponItem) weapon).AttackPower;
            return totalExtraAttackPower;
        }
        
        private int CalculateExtraDefensePower(BattleEquipments battleEquipments)
        {
            int totalExtraDefensePower = 0;
            List<Item> shields = battleEquipments.Equipments.FindAll(item => item is ShieldItem);
            List<Item> bodyArmors = battleEquipments.Equipments.FindAll(item => item is BodyArmorItem);

            foreach (ShieldItem shield in shields)
            {
                totalExtraDefensePower += shield.DefencePower;
            }
            foreach (BodyArmorItem armor in bodyArmors)
            {
                totalExtraDefensePower += armor.DefencePower;
            }

            return totalExtraDefensePower;
        }

    }
}