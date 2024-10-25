using System.Collections.Generic;
using Inventory_System.ScriptableObjects;

namespace Inventory_System.Model
{
    public class InventoryModel
    {
        internal readonly List<Item> _boughtItems = new List<Item>();
        internal List<Item> _selectedItems = new List<Item>();
        private BattleEquipments _playerBattleEquipments;

        public int Coin { get; private set; } = 10000;
            
        public void Initialize(BattleEquipments playerBattleEquipments)
        {
            _playerBattleEquipments = playerBattleEquipments;
        }

        public void AddItem(Item item)
        {
            _boughtItems.Add(item);
        }

        public void OnItemSelection(Item item)
        {
            if (_selectedItems.Contains(item))
                DeselectItem(item);
            else 
                SelectItem(item);
        }

        private void SelectItem(Item item)
        {
            if (item.Type != ItemType.BodyArmor)
            {
                // Remove the item with same type from list bcs it's a single item type
                _selectedItems.Remove(_selectedItems.Find(itemInList => itemInList.Type == item.Type)); 
            }
            _selectedItems.Add(item);
            _playerBattleEquipments.UpdateBattleEquipments(_selectedItems);
        }

        private void DeselectItem(Item item)
        {
            _selectedItems.Remove(item);
        }

        public void DecrementCoin(int amount)
        {
            Coin -= amount;
        }
        
        public void IncrementCoin(int amount)
        {
            Coin += amount;
        }
        
        

    }
}