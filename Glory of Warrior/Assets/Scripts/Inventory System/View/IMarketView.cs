using Inventory_System.ScriptableObjects;

namespace Inventory_System.View
{
    public delegate void SelectButtonDelegate(Item clickedItem);
    public delegate void BuyButtonDelegate(Item clickedItem);

    public interface IMarketView
    {
        void UpdateUIAfterBuy(Item item, int coin);
        void OnBuyButton(Item clickedItem);
        void OnSelectButton(Item clickedItem);
        
        event BuyButtonDelegate OnBuyButtonClicked;
        event SelectButtonDelegate OnSelectButtonClicked;
    }
}