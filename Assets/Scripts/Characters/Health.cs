using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float _point;
    [SerializeField] private float _maxPoint;

    public event Action HealthChanged;
    public event Action Died;

    public float MaxPoint => _maxPoint;
    public float Point => _point;

    public void Heal(float healPoint)
    {
        if (healPoint > 0)
            _point += healPoint;

        if (_point > _maxPoint)
            _point = _maxPoint;
        
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
            _point -= damage;

        if (_point <= 0)
            Died?.Invoke();
        
        HealthChanged?.Invoke();
    }
}
