using UnityEngine;

public abstract class PainterHealBase : MonoBehaviour
{
    [SerializeField] protected Health _health;
    
    private void OnEnable()
    {
        DrawHealth();
        _health.HealthChanged += DrawHealth;
    }

    private void OnDisable() =>
        _health.HealthChanged -= DrawHealth;

    protected abstract void DrawHealth();
}
