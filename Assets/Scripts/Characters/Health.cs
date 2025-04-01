using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthPoint;
    [SerializeField] private float _maxHealthPoint;

    public event Action HealthChanged;

    public float MaxHealthPoint => _maxHealthPoint;
    public float HealthPoint => _healthPoint;

    public void Heal(float healPoint)
    {
        if (healPoint > 0)
            _healthPoint += healPoint;

        if (_healthPoint > _maxHealthPoint)
            _healthPoint = _maxHealthPoint;
        
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
            _healthPoint -= damage;

        if (_healthPoint <= 0)
            Destroy(gameObject);
        
        Debug.Log(HealthPoint);
        HealthChanged?.Invoke();
    }
}
