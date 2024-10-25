using Inventory_System.Model;
using Inventory_System.ScriptableObjects;
using Inventory_System.View;

namespace Inventory_System.Controller
{
    public class InventoryController
    {
        private InventoryModel _inventoryModel;
        private InventoryView _inventoryView;
        private MarketModel _marketModel;
        private MarketView _marketView;

        public void Initialize(InventoryModel inventoryModel, InventoryView inventoryView, 
            MarketModel marketModel, MarketView marketView)
        {
            _inventoryModel = inventoryModel;            
            _marketModel = marketModel;
            _marketView = marketView;
            _inventoryView = inventoryView;

            _marketView.OnBuyButtonClicked += BuyItem;
            _marketView.OnSelectButtonClicked += SelectItem;
            _marketModel.OnItemBought += HandleBoughtItem;
        }

        private void BuyItem(Item item)
        {
            int currentCoin = _inventoryModel.Coin;
            _marketModel.BuyItem(item, currentCoin);
        }

        internal void HandleBoughtItem(Item item)
        {
            AddItemToInventory(item);
            SelectItem(item);
            DecrementCoin(item);
            UpdateUI(item);
        }

        private void AddItemToInventory(Item item)
        {
            _inventoryModel.AddItem(item);
        }

        private void SelectItem(Item item)
        {
            _inventoryModel.OnItemSelection(item);
            item.EquipStrategy.Equip(_inventoryView, item);
        }

        private void DecrementCoin(Item item)
        {
            _inventoryModel.DecrementCoin(item.Price);
        }

        private void UpdateUI(Item item)
        {
            _marketView.UpdateUIAfterBuy(item, _inventoryModel.Coin);
        }

        
        
        ~InventoryController() // Clean up with Destructor
        {
            _marketView.OnBuyButtonClicked -= BuyItem;
            _marketView.OnSelectButtonClicked -= SelectItem;
            _marketModel.OnItemBought -= HandleBoughtItem;
        }

    }
}