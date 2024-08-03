using System;
using Inventory_System.ScriptableObjects;
using JetBrains.Annotations;
using UnityEngine;

namespace Inventory_System
{
    public class MarketView: MonoBehaviour
    {
        //UI Items
        [SerializeField] [CanBeNull] private ItemStorage _itemStorage;

        public delegate void BuyButtonDelegate(Item clickedItem);
        public event BuyButtonDelegate OnBuyButtonClicked;

        public delegate void SelectButtonDelegate(Item clickedItem);
        public event SelectButtonDelegate OnSelectButtonClicked;


        public void ShowSelectableItems()
        {
            
        }

        public void LockExpensiveItems()
        {
            
        }

        public void UpdateUIAfterBuy(Item item, int coin)  // Item can be smt else later 
        {
            UpdateCoinText(coin);
            UpdateItemUI();
        }

        private void UpdateCoinText(int coinAmount)
        {
            
        }

        private void UpdateItemUI()
        {
            
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