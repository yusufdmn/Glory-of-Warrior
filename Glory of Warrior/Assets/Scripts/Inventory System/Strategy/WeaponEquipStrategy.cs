using Inventory_System.ScriptableObjects;
using Inventory_System.View;

namespace Inventory_System.Strategy
{
    public class WeaponEquipStrategy: IEquipStrategy
    {
        public void Equip(IInventoryView inventoryView, Item item)
        {
            inventoryView.RemoveReplacedItem(item.Id, item.Type);
            inventoryView.OnItemEquipment(item);
        }
    }
}