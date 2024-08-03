using Inventory_System.Strategy;
using UnityEngine;

namespace Inventory_System.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponItem", menuName = "Items/WeaponItem")]
    public class WeaponItem: Item
    {
        [SerializeField] private int _attackPower;
        public int AttackPower => _attackPower;
        public override IEquipStrategy EquipStrategy => new WeaponEquipStrategy();
        public override ItemType Type => ItemType.Weapon;
        public override SpawnParent SpawnParent => SpawnParent.RightHand;
        
        void OnEnable()
        {
            _equipStrategy = new WeaponEquipStrategy();
        }
    }
}