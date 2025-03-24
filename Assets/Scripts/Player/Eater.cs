using UnityEngine;

[RequireComponent(typeof(Health))]
public class Eater : MonoBehaviour
{
    private Health _health;

    private void Awake() => 
        _health = GetComponent<Health>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<HeallObject>(out HeallObject heallObject))
            _health.Heal(heallObject.Use());
        
        if (other.TryGetComponent(out FruitAnimation fruits))
            fruits.BeEaten();
    }
}
