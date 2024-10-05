namespace Health_System
{
    public class HealthController
    {
        private HealthModel _healthModel;
        private HealthView _healthView;

        public void Initialize(HealthModel healthModel, HealthView healthView)
        {
            _healthView = healthView;
            _healthModel = healthModel;
            healthView.Initialize(healthModel.MaxHealth);
            _healthModel.OnHealthChanged += UpdateView;
        }

        private void UpdateView()
        {
            _healthView.UpdateHealthBar(_healthModel.CurrentHealth);
        }

        ~HealthController()
        {
            _healthModel.OnHealthChanged -= UpdateView;
        }
    }
}