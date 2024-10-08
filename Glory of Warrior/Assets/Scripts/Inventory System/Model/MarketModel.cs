using Inventory_System.ScriptableObjects;

namespace Inventory_System.Model
{
    public class MarketModel
    {
        public Item[] MarketItems { get; set; }
        
        public delegate void OnItemBoughtDelegate(Item item);
        public event OnItemBoughtDelegate OnItemBought;

        public void BuyItem(Item item ,int currentCoin)
        {
            if (item.Price > currentCoin)
                return;
            
            OnItemBought?.Invoke(item);
        }
    }
}