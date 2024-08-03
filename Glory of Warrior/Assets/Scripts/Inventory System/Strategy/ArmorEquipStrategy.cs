using Inventory_System.ScriptableObjects;

namespace Inventory_System.Strategy
{
    public class ArmorEquipStrategy: IEquipStrategy
    {
        public void Equip(InventoryView inventoryView, Item item)
        {
            inventoryView.OnItemEquipment(item);
        }
    }
}