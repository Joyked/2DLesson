using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : PainterHealBase
{
    [SerializeField] private float _speed = 1.0f;
    
    private Slider _slider;
    private float _currentHealth;
    private float _targetHealth;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.MaxHealthPoint;
        _currentHealth = _health.HealthPoint;
        _slider.value = _currentHealth;
    }

    private void Update()
    {
        if (_currentHealth != _targetHealth)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _targetHealth, _speed * Time.deltaTime);
            _slider.value = _currentHealth;
        }
    }

    protected override void DrawHealth() =>
        _targetHealth = _health.HealthPoint;
}
