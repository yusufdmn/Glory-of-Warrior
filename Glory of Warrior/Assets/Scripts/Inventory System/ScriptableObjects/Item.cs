using Inventory_System.Strategy;
using Inventory_System.View;
using UnityEngine;

namespace Inventory_System.ScriptableObjects
{
    public enum ItemType
    {
        Weapon,
        BodyArmor,
        Shield
    }
    public abstract class Item: ScriptableObject
    {
        
        [SerializeField] private int _id;
        [SerializeField] private int _price;
        [SerializeField] private GameObject _itemPrefab;
        public IEquipStrategy _equipStrategy;
        
        public abstract IEquipStrategy EquipStrategy { get; }
        public abstract SpawnParent SpawnParent { get; }
        public abstract ItemType Type { get; }
        public GameObject ItemPrefab { get => _itemPrefab; set => _itemPrefab = value; }
        public int Id => _id;
        public int Price
        {
            get => _price;
            set => _price = value;
        }

    }
}