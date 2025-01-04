using System;
using Gameplay_System.Factory.Params;
using Health_System.Initializer;
using Zenject;

namespace Gameplay_System.Factory
{
    public class HealthSystemInitializerFactory : PlaceholderFactory<HealthSystemInitializerParams, HealthSystemInitializer>
    {
        private DiContainer _container;
        
        [Inject]
        public HealthSystemInitializerFactory(DiContainer container)
        {
            _container = container;
        }
        
        public override HealthSystemInitializer Create(HealthSystemInitializerParams parameters)
        {
            if (parameters.Target == null)
            {
                throw new ArgumentNullException(nameof(parameters.Target), "Target GameObject cannot be null");
            }

            // Dynamically add the HealthSystemInitializer component
            var initializer = parameters.Target.AddComponent<HealthSystemInitializer>();
            _container.Inject(initializer);
            
            // Initialize the component with parameters
            initializer.LaunchTheInitializer(parameters.Equipments, parameters.DeathStrategy, parameters.HealthMultiplier);

            return initializer;
        }
    }
}