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
        [Inject] private InventoryController _inventoryController;
        [Inject] private InventoryModel _inventoryModel;
        [Inject] private MarketModel _marketModel;
        [Inject] private MarketView _marketView;
        [Inject] private InventoryView _inventoryView;
        [Inject] private ItemStorage _itemStorage;
        
        [SerializeField] private BattleEquipments _playerBattleEquipments;
        
        public void InitializeSystem()
        {
            _inventoryModel.Initialize(_playerBattleEquipments);
            _marketModel.MarketItems = _itemStorage.AllItems;
            _inventoryController.Initialize(_inventoryModel, _inventoryView, _marketModel, _marketView);
        }

        private void Awake()
        {
            InitializeSystem();
        }
    }
}