using Inventory_System.ScriptableObjects;

namespace Inventory_System.Model
{
    public delegate void OnItemBoughtDelegate(Item item);

    public interface IMarketModel
    {
        void BuyItem(Item item, int currentCoin);
        
        event OnItemBoughtDelegate OnItemBought;

        Item[] MarketItems { get; set; }
    }
}