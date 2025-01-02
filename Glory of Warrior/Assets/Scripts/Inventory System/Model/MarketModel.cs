using Inventory_System.ScriptableObjects;
namespace Inventory_System.Model
{
    public class MarketModel: IMarketModel
    {
        public Item[] MarketItems { get; set; }
        public event OnItemBoughtDelegate OnItemBought;

        public void BuyItem(Item item ,int currentCoin)
        {
            if (item.Price > currentCoin)
                return;
            
            OnItemBought?.Invoke(item);
        }

    }
}