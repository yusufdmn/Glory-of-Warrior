using Health_System;
using Inventory_System.Controller;
using Inventory_System.Model;
using Inventory_System.View;
using Inventory_System.View.Helper;
using Zenject;

namespace Inventory_System.DI
{
    public class ZenjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ItemStorage>().FromComponentInHierarchy().AsTransient();
            Container.Bind<MarketModel>().AsSingle();
            Container.Bind<InventoryModel>().AsSingle();
            Container.Bind<InventoryController>().AsSingle();
            Container.Bind<InventoryView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MarketView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BoneStorage>().FromComponentInHierarchy().AsSingle();
        }
    }
}
