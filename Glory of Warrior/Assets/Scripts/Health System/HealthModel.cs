using System;
using Health_System.Strategy;
using Zenject.SpaceFighter;

namespace Health_System
{
    public class HealthModel
    {
        private IDeathStrategy _deathStrategy;

        public delegate void OnHealthChangedDelegate();
        public event OnHealthChangedDelegate OnHealthChanged;
        
        public int MinHealth { get; private set; }
        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }

        public HealthModel(int maxHealth, IDeathStrategy deathStrategy)
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
            
            if(CurrentHealth < MinHealth)
                Die();
        }

        private void Die()
        {
            _deathStrategy.Execute();
        }
        
    }
}