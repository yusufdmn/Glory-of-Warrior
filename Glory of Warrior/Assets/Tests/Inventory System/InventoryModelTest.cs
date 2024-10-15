using System.Collections;
using System.Reflection;
using Inventory_System.Model;
using Inventory_System.ScriptableObjects;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Tests.Inventory_System
{
    public class InventoryModelTest
    {
        private InventoryModel _inventoryModel;
        private DiContainer _container;
        private Item _item1;
        
        [SetUp]
        public void SetUp()
        {
            _container = new DiContainer();
            
            _container.Bind<InventoryModel>().AsSingle();
            _container.Bind<MarketModel>().AsSingle();
            _inventoryModel = _container.Resolve<InventoryModel>();
            
            BattleEquipments battleEquipments = ScriptableObject.CreateInstance<BattleEquipments>();
            _inventoryModel.Initialize(battleEquipments);

            _item1 = ScriptableObject.CreateInstance<BodyArmorItem>();
            _item1.ItemPrefab = _container.CreateEmptyGameObject("emptyObject");
        }
        
        [Test]
        public void AddItemTest()
        {
            _inventoryModel.AddItem(_item1);
            Assert.Contains(_item1, (ICollection) GetPrivateField(_inventoryModel, "_boughtItems"), 
                "Item should be added to the list.");
        }
                
        [Test]
        public void SelectItemTest()
        {
            _inventoryModel.OnItemSelection(_item1);
            Assert.AreEqual(1, _inventoryModel._selectedItems.Count, "SelectedItems should contain 1 item.");
            Assert.AreEqual(_item1, _inventoryModel._selectedItems[0], "SelectedItems should contain item1.");
        }
        
        [Test]
        public void BuyItemTest()
        {
            _inventoryModel.AddItem(_item1);
            Assert.Contains(_item1, (ICollection) GetPrivateField(_inventoryModel, "_boughtItems"), 
                "Item should be added to the list.");
        }
        
        [Test]
        public void DeselectItemTest()
        {
            _inventoryModel.OnItemSelection(_item1);
            _inventoryModel.OnItemSelection(_item1);
            Assert.AreEqual(0, _inventoryModel._selectedItems.Count, "SelectedItems should be empty.");
        }


        // tear down
        [TearDown]
        public void TearDown()
        {
            _inventoryModel = null;
            _item1 = null;
        }

        private object GetPrivateField(object someObject, string fieldName) =>
            someObject.GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)?
                .GetValue(someObject);

    }
}