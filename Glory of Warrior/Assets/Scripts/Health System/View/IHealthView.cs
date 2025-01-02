namespace Health_System.View
{
    public interface IHealthView
    {
        void Initialize(int maxHealth);
        void UpdateHealthBar(int currentHealth);
    }
}