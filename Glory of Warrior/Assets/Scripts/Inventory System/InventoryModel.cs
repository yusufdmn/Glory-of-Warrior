using System.Collections.Generic;
using System.Linq;
using Inventory_System.ScriptableObjects;

namespace Inventory_System
{
    public class InventoryModel
    {
        private readonly List<Item> _boughtItems = new List<Item>();
        private List<Item> _selectedItems = new List<Item>();

        public int Coin { get; private set; } = 10000;

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
            if (item.Type == ItemType.BodyArmor)
            {
                _selectedItems.Add(item);
                return;
            }
            // Remove the item with same type from list.
            _selectedItems.Remove(_selectedItems.Find(itemInList => itemInList.Type == item.Type)); 
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