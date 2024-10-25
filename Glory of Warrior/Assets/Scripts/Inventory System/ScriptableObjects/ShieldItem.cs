using Inventory_System.Strategy;
using Inventory_System.View;
using UnityEngine;

namespace Inventory_System.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ShieldItem", menuName = "Items/ShieldItem")]
    public class ShieldItem: Item
    {
        [SerializeField] private int _defencePower;
        [SerializeField] private int _healthValue;
        
        public override IEquipStrategy EquipStrategy => _equipStrategy;
        public override ItemType Type => ItemType.Shield;
        public int DefencePower => _defencePower;        
        public int HealthValue => _healthValue;
        public override SpawnParent SpawnParent => SpawnParent.LeftHand;
        
        void OnEnable()
        {
            _equipStrategy = new ShieldEquipStrategy();
        }
    }
}