using Inventory_System.ScriptableObjects;
using Inventory_System.View;

namespace Inventory_System.Strategy
{
    public interface IEquipStrategy
    {
        void Equip(IInventoryView inventoryView, Item item);
    }
}