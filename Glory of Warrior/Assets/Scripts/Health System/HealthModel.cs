using System;
using Health_System.Strategy;

namespace Health_System
{
    public class HealthModel
    {
        private IDeathStrategy _deathStrategy;

        public delegate void OnHealthChangedDelegate();
        public event OnHealthChangedDelegate OnHealthChanged;
        public delegate void OnDeathDelegate();
        public event OnDeathDelegate OnDeath;
        
        public int MinHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }

        public void Initialize(int maxHealth, IDeathStrategy deathStrategy)
        {
            MinHealth = 0;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            _deathStrategy = deathStrategy;
        }

        public void IncreaseHealth(int increaseAmount)
        {
            int increasedHealth = CurrentHealth + increaseAmount;
            CurrentHealth = Math.Min(MaxHealth, increasedHealth);
            OnHealthChanged?.Invoke();
        }
        
        public void DecreaseHealth(int decreaseAmount)
        {
            int decreasedHealth = CurrentHealth - decreaseAmount;
            CurrentHealth = Math.Max(MinHealth, decreasedHealth);
            OnHealthChanged?.Invoke();
            
            if(CurrentHealth <= MinHealth)
                Die();
        }

        private void Die()
        {
            OnDeath?.Invoke();
            _deathStrategy.Execute();
        }
        
    }
}