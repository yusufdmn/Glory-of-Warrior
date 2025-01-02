using Inventory_System.Controller;
using Inventory_System.Model;
using Inventory_System.ScriptableObjects;
using Inventory_System.View;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Inventory_System
{
    public class InventoryControllerTest
    {
        private InventoryController _inventoryController;
        private IInventoryModel _mockInventoryModel;
        private IInventoryView _mockInventoryView;
        private IMarketModel _mockMarketModel;
        private IMarketView _mockMarketView;
        private Item _mockItem;

        [SetUp]
        public void SetUp()
        {
            // mocks
            _mockInventoryModel = Substitute.For<IInventoryModel>();
            _mockInventoryView = Substitute.For<IInventoryView>();
            _mockMarketModel = Substitute.For<IMarketModel>();
            _mockMarketView = Substitute.For<IMarketView>();
            _mockItem = Substitute.For<WeaponItem>();

            // Create the controller and initialize
            _inventoryController = new InventoryController();
            _inventoryController.Initialize(_mockInventoryModel, _mockInventoryView, _mockMarketModel, _mockMarketView);
        }

        [Test]
        public void HandleBoughtItem()
        {
            // Arrange
            var itemPrice = 50;
            var startingCoins = 100;

            _mockItem.Price = itemPrice;
            _mockInventoryModel.Coin.Returns(startingCoins);

            // Raise the OnItemBought event 
            _mockMarketModel.OnItemBought += Raise.Event<OnItemBoughtDelegate>(_mockItem);

            // Assert
            _mockInventoryModel.Received(1).AddItem(_mockItem);
            _mockInventoryModel.Received(1).DecrementCoin(itemPrice);
            _mockInventoryModel.Received(1).OnItemSelection(_mockItem);
            _mockItem.EquipStrategy.Received(1).Equip(_mockInventoryView, _mockItem);
        }


        [Test]
        public void BuyItem_Should_Call_MarketModel_BuyItem()
        {
            // Arrange
            var item = _mockItem;
            var currentCoins = 100;
            _mockInventoryModel.Coin.Returns(currentCoins);

            // Raise the OnBuyButtonClicked event
            _mockMarketView.OnBuyButtonClicked += Raise.Event<BuyButtonDelegate>(item);

            // Assert
            _mockMarketModel.Received(1).BuyItem(item, currentCoins);
        }

        [Test]
        public void Destructor_Should_Unsubscribe_Events()
        {
            // Arrange
            _inventoryController = null;

            // Act
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            // Assert
            _mockMarketView.DidNotReceive().OnBuyButtonClicked -= Arg.Any<BuyButtonDelegate>();
            _mockMarketView.DidNotReceive().OnSelectButtonClicked -= Arg.Any<SelectButtonDelegate>();
            _mockMarketModel.DidNotReceive().OnItemBought -= Arg.Any<OnItemBoughtDelegate>();
        }
    }
}
