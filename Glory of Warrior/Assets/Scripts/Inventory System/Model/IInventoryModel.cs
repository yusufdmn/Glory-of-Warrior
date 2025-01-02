using System.Collections.Generic;
using Inventory_System.ScriptableObjects;

namespace Inventory_System.Model
{
    public interface IInventoryModel
    {
        void Initialize(BattleEquipments playerBattleEquipments);
        void AddItem(Item item);
        void OnItemSelection(Item item);
        void DecrementCoin(int amount);
        void IncrementCoin(int amount);
        int Coin { get; }
        IReadOnlyList<Item> BoughtItems { get; }
        IReadOnlyList<Item> SelectedItems { get; }
    }
}