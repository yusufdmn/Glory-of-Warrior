using System.Collections.Generic;
using UnityEngine;

namespace Inventory_System.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BattleEquipments", menuName = "Equipments")]
    public class BattleEquipments:ScriptableObject
    {
        [SerializeField] private List<Item> _equipments;
        public List<Item> Equipments
        {
            get => _equipments; 
            private set => _equipments = value;
        }
        
        public void UpdateBattleEquipments(List<Item> equipments)
        {
            Equipments = equipments;
        }
    }
}