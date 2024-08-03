using Inventory_System.ScriptableObjects;

namespace Inventory_System.Strategy
{
    public interface IEquipStrategy
    {
        public void Equip(InventoryView inventoryView, Item item);
    }
}