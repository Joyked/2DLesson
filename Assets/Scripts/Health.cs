using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthPoint;
    [SerializeField] private float _maxHealthPoint;

    public void Heal(float healPoint)
    {
        if (healPoint > 0)
            _healthPoint += healPoint;

        if (_healthPoint > _maxHealthPoint)
            _healthPoint = _maxHealthPoint;
        
        Debug.Log(_healthPoint);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
            _healthPoint -= damage;

        if (_healthPoint <= 0)
            Destroy(gameObject);
        
        Debug.Log(_healthPoint);
    }
}
