using Inventory_System.Model;
using Inventory_System.View;

namespace Inventory_System.Controller
{
    public interface IInventoryController
    {
        void Initialize(IInventoryModel inventoryModel, IInventoryView inventoryView,
            IMarketModel marketModel, IMarketView marketView);
    }
}