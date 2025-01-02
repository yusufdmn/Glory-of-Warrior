using Health_System.Model;
using Health_System.Strategy;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Health__System
{
    public class HealthModelTest
    {
        private IHealthModel _healthModel;
        private IDeathStrategy _mockDeathStrategy;

        [SetUp]
        public void Setup()
        {
            // Create mock for IPlayerDeathStrategy
            _mockDeathStrategy = Substitute.For<PlayerDeathStrategy>();

            // Instantiate the object under test (HealthModel)
            _healthModel = new HealthModel();
            _healthModel.Initialize(100, _mockDeathStrategy);
            
        }

        [Test]
        public void InitializeHealthCorrectly()
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
        }

        [Test]
        public void HealthIncreasesCorrectly()
        {
            _healthModel.DecreaseHealth(50);
            _healthModel.IncreaseHealth(20);
            Assert.AreEqual(70, _healthModel.CurrentHealth, "CurrentHealth should be increased by 20.");

            // Test health does not exceed maximum
            _healthModel.IncreaseHealth(150);
            Assert.AreEqual(_healthModel.MaxHealth, _healthModel.CurrentHealth, "CurrentHealth should not exceed MaxHealth.");
        }
        
        
        [TearDown]
        public void TearDown()
        {
            _healthModel = null;
            _mockDeathStrategy = null;
        }
    }
}
