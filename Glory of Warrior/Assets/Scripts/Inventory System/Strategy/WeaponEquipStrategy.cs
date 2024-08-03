using Inventory_System.ScriptableObjects;

namespace Inventory_System.Strategy
{
    public class WeaponEquipStrategy: IEquipStrategy
    {
        public void Equip(InventoryView inventoryView, Item item)
        {
            inventoryView.RemoveReplacedItem(item.Id, item.Type);
            inventoryView.OnItemEquipment(item);
        }
    }
}