using Gameplay_System.Animation_Management;
using Gameplay_System.Helper.Movements;
using Gameplay_System.Helper.Weapons;
using Gameplay_System.Model;
using Health_System;
using Health_System.Model;
using Health_System.Strategy;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using Zenject;

namespace Tests.Gameplay_System
{
    public class WarriorModelTest
    {
        private DiContainer _container;
        private TestWarriorModel _warriorModel;
        private Weapon _weapon;
        private HealthModel _healthModel;
        private IMovement _mockMovement;
        private IAnimationManager _mockAnimationManager;

        [SetUp]
        public void SetUp()
        {
            _container = new DiContainer();

            // Bind mocks
            _container.Bind<SwordWeapon>().FromNewComponentOnNewGameObject().AsTransient();
            _container.Bind<IHealthModel>().AsTransient();
            _container.Bind<TestWarriorModel>().AsTransient();
            _container.Bind<IMovement>().FromInstance(Substitute.For<IMovement>());
            _container.Bind<IAnimationManager>().FromInstance(Substitute.For<IAnimationManager>());

            // resolve mocks
            _healthModel = _container.Resolve<HealthModel>();
            _weapon = _container.Resolve<SwordWeapon>();
            _warriorModel = _container.Resolve<TestWarriorModel>();
            _mockMovement = _container.Resolve<IMovement>();
            _mockAnimationManager = _container.Resolve<IAnimationManager>();

           // _warriorModel = Substitute.For<TestWarriorModel>();
            _warriorModel.Initialize(_weapon, _healthModel, 10, 5, _mockMovement, _mockAnimationManager);

            _healthModel.Initialize(100, new EnemyDeathStrategy());
        }
        
        [Test]
        public void TakeDamageTest()
        {
            _warriorModel.TakeDamage(10);
            Assert.AreEqual(90, _warriorModel._healthModel.CurrentHealth, "Health should be 90 after taking 10 damage.");
        }
        
        [TearDown]
        public void TearDown()
        {
            _container.UnbindAll();
            _container = null;
            _warriorModel = null;
            _weapon = null;
            _healthModel = null;
            _mockMovement = null;
            _mockAnimationManager = null;
        }
        
    }


    // Concrete implementation of WarriorModel for testing
    public class TestWarriorModel : WarriorModel
    {
        public void Initialize(Weapon weapon, HealthModel healthModel, int attackPower, int defensePower,
            IMovement movement, IAnimationManager animationManager)
        {
            base.Initialize(weapon, healthModel, attackPower, defensePower);
        }
    }
    
}