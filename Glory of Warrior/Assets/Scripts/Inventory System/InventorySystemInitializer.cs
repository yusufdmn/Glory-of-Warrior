using Helper.Interfaces;
using Inventory_System.Controller;
using Inventory_System.Model;
using Inventory_System.ScriptableObjects;
using Inventory_System.View;
using UnityEngine;
using Zenject;

namespace Inventory_System
{
    public class InventorySystemInitializer: MonoBehaviour, ISystemInitializer
    {
        private IInventoryController _inventoryController;
        private IInventoryModel _inventoryModel;
        private IMarketModel _marketModel;
        private IMarketView _marketView;
        private ItemStorage _itemStorage;
        private IInventoryView _inventoryView;
        
        [SerializeField] private BattleEquipments _playerBattleEquipments;
        
        [Inject]
        private void Construct(IInventoryController inventoryController, IInventoryModel inventoryModel, 
            IMarketModel marketModel, IMarketView marketView, IInventoryView inventoryView, ItemStorage itemStorage)
        {
            _inventoryController = inventoryController;
            _inventoryModel = inventoryModel;
            _marketModel = marketModel;
            _marketView = marketView;
            _inventoryView = inventoryView;
            _itemStorage = itemStorage;
            InitializeSystem();
        }
        
        public void InitializeSystem()
        {
            _inventoryModel.Initialize(_playerBattleEquipments);
            _marketModel.MarketItems = _itemStorage.AllItems;
            _inventoryController.Initialize(_inventoryModel, _inventoryView, _marketModel, _marketView);
        }

        // private void Awake()
        // {
        //     InitializeSystem();
        // }
    }
}