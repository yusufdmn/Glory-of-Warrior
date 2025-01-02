using UnityEngine;
using UnityEngine.UI;

namespace Health_System.View
{
    public class HealthView: MonoBehaviour, IHealthView
    {
        private Slider _healthBarSlider;
        private float _healthValue;

        private void Awake()
        {
            _healthBarSlider = GetComponent<Slider>();
        }

        public void Initialize(int maxHealth)
        {
            _healthBarSlider.maxValue = maxHealth;
            UpdateHealthBar(maxHealth);
        }

        public void UpdateHealthBar(int currentHealth)
        {
            _healthValue = currentHealth;
            _healthBarSlider.value = _healthValue;
        }
    }
}