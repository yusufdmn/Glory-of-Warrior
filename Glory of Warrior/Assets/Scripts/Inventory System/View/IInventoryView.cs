using Inventory_System.ScriptableObjects;

namespace Inventory_System.View
{
    public interface IInventoryView
    {
        void OnItemEquipment(Item item);
        void RemoveReplacedItem(int id, ItemType type);
    }
}