using Inventory_System.ScriptableObjects;
using Inventory_System.View;

namespace Inventory_System.Strategy
{
    public class ShieldEquipStrategy: IEquipStrategy
    {
        public void Equip(InventoryView inventoryView, Item item)
        {
            inventoryView.RemoveReplacedItem(item.Id, item.Type);
            inventoryView.OnItemEquipment(item);
        }
    }
}