using Health_System.Model;
using Health_System.View;

namespace Health_System.Controller
{
    public class HealthController: IHealthController
    {
        private IHealthModel _healthModel;
        private IHealthView _healthView;

        public void Initialize(IHealthModel healthModel, IHealthView healthView)
        {
            _healthView = healthView;
            _healthModel = healthModel;
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