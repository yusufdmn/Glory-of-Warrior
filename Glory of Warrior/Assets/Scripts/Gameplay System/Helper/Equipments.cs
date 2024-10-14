using Inventory_System.ScriptableObjects;
using UnityEngine;

namespace Gameplay_System.Helper
{
    public class Equipments: MonoBehaviour
    {
        [SerializeField] private BattleEquipments _equippedItems;
        public BattleEquipments EquippedItems => _equippedItems;
    }
    
}