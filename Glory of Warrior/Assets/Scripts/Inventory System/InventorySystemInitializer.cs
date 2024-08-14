using System;
using Common.Interfaces;
using UnityEngine;
using Zenject;

namespace Inventory_System
{
    public class InventorySystemInitializer: MonoBehaviour, ISystemInitializer
    {
        [Inject] private InventoryController _inventoryController;
        [Inject] private InventoryModel _inventoryModel;
        [Inject] private MarketModel _marketModel;
        [Inject] private MarketView _marketView;
        [Inject] private InventoryView _inventoryView;
        [Inject] private ItemStorage _itemStorage;
        
        public void InitializeSystem()
        {
            _marketModel.MarketItems = _itemStorage.AllItems;
            _inventoryController.Initialize(_inventoryModel, _inventoryView, _marketModel, _marketView);
        }

        private void Awake()
        {
            InitializeSystem();
        }
    }
}