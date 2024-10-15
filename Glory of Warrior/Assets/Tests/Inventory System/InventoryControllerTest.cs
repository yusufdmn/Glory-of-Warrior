using System.Reflection;
using Inventory_System.Controller;
using Inventory_System.Model;
using Inventory_System.ScriptableObjects;
using Inventory_System.View;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Tests.Inventory_System
{
    public class InventoryControllerTest
    {
        private InventoryController _inventoryController;
        private InventoryModel _inventoryModel;
        private InventoryView _inventoryView;
        private MarketModel _marketModel;
        private MarketView _marketView;
        private DiContainer _container;

        private Item item1;
        
        [SetUp]
        public void SetUp()
        {
            _container = new DiContainer();
            
            // Bind required components using Zenject
            _container.Bind<InventoryModel>().AsSingle();
            _container.Bind<MarketModel>().AsSingle();
            _container.Bind<InventoryController>().AsSingle();
            _container.Bind<InventoryView>().FromNewComponentOnNewGameObject().AsSingle();
            _container.Bind<MarketView>().FromNewComponentOnNewGameObject().AsSingle();
        
            // Resolve all dependencies
            _marketView = _container.Resolve<MarketView>();
            _inventoryModel = _container.Resolve<InventoryModel>();
            _marketModel = _container.Resolve<MarketModel>();
            _inventoryView = _container.Resolve<InventoryView>();

            _container.Inject(_inventoryView);

            // Set up initialize the inventory view and inventory model
            Transform _mockTransform = _container.CreateEmptyGameObject("emptyObj").transform;
            SetPrivateField(_inventoryView, "_rightHandTransform", _mockTransform);
            SetPrivateField(_inventoryView, "_leftHandTransform", _mockTransform);
            SetPrivateField(_inventoryView, "_armorSlotTransform", _mockTransform);
            _inventoryView.Start();

            BattleEquipments battleEquipments = ScriptableObject.CreateInstance<BattleEquipments>();
            _inventoryModel.Initialize(battleEquipments);
        
            // Initialize the controller
            _inventoryController = _container.Resolve<InventoryController>();
            _inventoryController.Initialize(_inventoryModel, _inventoryView, _marketModel, _marketView);

            item1 = ScriptableObject.CreateInstance<BodyArmorItem>();
            item1.ItemPrefab = _container.CreateEmptyGameObject("emptyObject");
        }

        [Test]
        public void HandleBoughtItemTest()
        {
            _inventoryController.HandleBoughtItem(item1);
            Assert.AreEqual(1, _inventoryModel._boughtItems.Count, "BoughtItems should contain 1 item.");
            Assert.AreEqual(item1, _inventoryModel._boughtItems[0], "BoughtItems should contain item1.");
        }
        
        private void SetPrivateField(object someObject, string fieldName, object value) => 
            someObject.GetType()
                .GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)?
                .SetValue(someObject, value);
                
    }
}