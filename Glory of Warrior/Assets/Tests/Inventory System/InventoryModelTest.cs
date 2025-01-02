using Inventory_System.Model;
using Inventory_System.ScriptableObjects;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Inventory_System
{
    public class InventoryModelTest
    {
        private IInventoryModel _inventoryModel; // Use interface for dependency inversion
        private BattleEquipments _mockBattleEquipments;
        private Item _mockItem;

        [SetUp]
        public void SetUp()
        {
            // Mock the BattleEquipments dependency
            _mockBattleEquipments = Substitute.For<BattleEquipments>();
            _mockItem = Substitute.For<WeaponItem>();

            // Create the InventoryModel with the mocked dependency
            _inventoryModel = new InventoryModel();
            _inventoryModel.Initialize(_mockBattleEquipments);

            // Create a mock item
        }

        [Test]
        public void AddItemTest()
        {
            _inventoryModel.AddItem(_mockItem);
            CollectionAssert.Contains(_inventoryModel.BoughtItems, _mockItem, "Item should be added to the list.");
        }

        [Test]
        public void SelectItemTest()
        {
            _inventoryModel.OnItemSelection(_mockItem);
            Assert.AreEqual(1, _inventoryModel.SelectedItems.Count, "SelectedItems should contain 1 item.");
            Assert.AreEqual(_mockItem, _inventoryModel.SelectedItems[0], "SelectedItems should contain item1.");
        }

        [Test]
        public void BuyItemTest()
        {
            _inventoryModel.AddItem(_mockItem);
            CollectionAssert.Contains(_inventoryModel.BoughtItems, _mockItem, "Item should be added to the list.");
        }

        [Test]
        public void DeselectItemTest()
        {
            _inventoryModel.OnItemSelection(_mockItem);
            _inventoryModel.OnItemSelection(_mockItem);
            Assert.AreEqual(0, _inventoryModel.SelectedItems.Count, "SelectedItems should be empty.");
        }

        [TearDown]
        public void TearDown()
        {
            _inventoryModel = null;
            _mockItem = null;
        }
    }
}
