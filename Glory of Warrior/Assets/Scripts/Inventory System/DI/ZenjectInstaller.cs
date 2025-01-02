using Helper;
using Inventory_System.Controller;
using Inventory_System.Model;
using Inventory_System.View;
using Zenject;

namespace Inventory_System.DI
{
    public class ZenjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInventoryController>().To<InventoryController>().AsSingle();
            Container.Bind<IInventoryModel>().To<InventoryModel>().AsSingle();
            Container.Bind<IMarketModel>().To<MarketModel>().AsSingle();
            Container.Bind<IMarketView>().To<MarketView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IInventoryView>().To<InventoryView>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<ItemStorage>().FromComponentInHierarchy().AsTransient();
            Container.Bind<BoneStorage>().FromComponentInHierarchy().AsSingle();
        }
    }
}
