using System.Reflection;
using Health_System;
using Health_System.Strategy;
using NUnit.Framework;
using UnityEngine.UI;
using Zenject;

namespace Tests
{
    public class HealthModelTest{
        
        private HealthModel _healthModel;
        private HealthController _healthController;
        private HealthView _healthView;
        private PlayerDeathStrategy _deathStrategy;
        private DiContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new DiContainer();
            
            // Bind 
            _container.Bind<HealthModel>().AsTransient();
            _container.Bind<HealthController>().AsTransient();
            _container.Bind<PlayerDeathStrategy>().AsTransient();
            _container.Bind<HealthView>().FromNewComponentOnNewGameObject().AsTransient();

            // Resolve
            _healthModel = _container.Resolve<HealthModel>();
            _healthController = _container.Resolve<HealthController>();
            _healthView = _container.Resolve<HealthView>();
            _deathStrategy = _container.Resolve<PlayerDeathStrategy>();

            // Set up and initialize
            SetUpHealthView(_healthView);
            _healthModel.Initialize(100, _deathStrategy); 
            _healthController.Initialize(_healthModel, _healthView);
        }

        [Test]
        public void SetsHealthCorrectly()
        {
            Assert.AreEqual(100, _healthModel.MaxHealth, "MaxHealth should be initialized correctly.");
            Assert.AreEqual(100, _healthModel.CurrentHealth, "CurrentHealth should be initialized to MaxHealth.");
            Assert.AreEqual(0, _healthModel.MinHealth, "MinHealth should be initialized to 0.");
        }
        
        [Test]
        public void HealthDecreasesCorrectly()
        {
            _healthModel.DecreaseHealth(10);
            Assert.AreEqual(90, _healthModel.CurrentHealth, "CurrentHealth should be decreased by 10.");
            
            // Does the health decrease correctly when the health is already at the minimum health
            _healthModel.DecreaseHealth(150);
            Assert.AreEqual(_healthModel.MinHealth, _healthModel.CurrentHealth, "CurrentHealth should be decreased to MinHealth.");
        }

        [Test]
        public void HealthIncreaseCorrectly()
        {
            _healthModel.DecreaseHealth(50);
            _healthModel.IncreaseHealth(20);
            Assert.AreEqual(70, _healthModel.CurrentHealth, "CurrentHealth should be increased by 20.");
            
            // Does the health increase correctly when the health is already at the maximum health
            _healthModel.IncreaseHealth(50);
            Assert.AreEqual(_healthModel.MaxHealth, _healthModel.CurrentHealth, "CurrentHealth should be increased to MaxHealth.");
        }
        

        [TearDown]
        public void TearDown()
        {
            _container.UnbindAll();
            _healthModel = null;
            _healthController = null;
            _healthView = null;
            _deathStrategy = null;
            _container = null;
        }
        
        private void SetUpHealthView(HealthView healthView)
        {
            healthView.gameObject.AddComponent<Slider>();
            SetPrivateField(healthView, "_healthBarSlider", healthView.GetComponent<Slider>());
        }
        
        private void SetPrivateField(object someObject, string fieldName, object value) => 
            someObject.GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)?
                .SetValue(someObject, value);

    }
}
