using Health_System.Strategy;

namespace Health_System.Model
{
    public delegate void OnHealthChangedDelegate();
    public delegate void OnDeathDelegate();

    public interface IHealthModel
    {
        int MaxHealth { get; }
        int MinHealth { get; }
        int CurrentHealth { get; } 
        void Initialize(int maxHealth, IDeathStrategy deathStrategy);
        void IncreaseHealth(int increaseAmount);
        void DecreaseHealth(int decreaseAmount);
        event OnHealthChangedDelegate OnHealthChanged;
        event OnDeathDelegate OnDeath;
    }
}