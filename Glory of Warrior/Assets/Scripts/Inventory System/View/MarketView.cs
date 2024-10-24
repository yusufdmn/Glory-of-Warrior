using Inventory_System.ScriptableObjects;
using UnityEngine;

namespace Inventory_System.View
{
    public class MarketView: MonoBehaviour
    {
        //UI Items
        [SerializeField] private ItemStorage _itemStorage;

        public delegate void BuyButtonDelegate(Item clickedItem);
        public event BuyButtonDelegate OnBuyButtonClicked;

        public delegate void SelectButtonDelegate(Item clickedItem);
        public event SelectButtonDelegate OnSelectButtonClicked;


        public void ShowSelectableItems()
        {
            // will be implemented later
        }

        public void LockExpensiveItems()
        {
            // will be implemented later
        }

        public void UpdateUIAfterBuy(Item item, int coin)  // Item can be smt else later 
        {
            UpdateCoinText(coin);
            UpdateItemUI();
        }

        private void UpdateCoinText(int coinAmount)
        {
            // will be implemented later
        }

        private void UpdateItemUI()
        {
            // will be implemented later
        }

        public void OnBuyButton(Item clickedItem)
        {
            OnBuyButtonClicked?.Invoke(clickedItem);
        }

        public void OnSelectButton(Item clickedItem)
        {
            OnSelectButtonClicked?.Invoke(clickedItem);
        }
    }
}