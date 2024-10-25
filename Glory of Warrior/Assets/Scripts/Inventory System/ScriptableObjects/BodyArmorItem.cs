using Inventory_System.Strategy;
using Inventory_System.View;
using UnityEngine;

namespace Inventory_System.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BodyArmorItem", menuName = "Items/BodyArmorItem")]
    public class BodyArmorItem: Item
    {
        [SerializeField] private int _defencePower;
        [SerializeField] private int _healthValue;
        public override IEquipStrategy EquipStrategy => _equipStrategy;

        public int DefencePower => _defencePower;        
        public int HealthValue => _healthValue;
        public override ItemType Type => ItemType.BodyArmor;
        public override SpawnParent SpawnParent => SpawnParent.Player;

        void OnEnable()
        {
            _equipStrategy = new ArmorEquipStrategy();
        }
    }
}