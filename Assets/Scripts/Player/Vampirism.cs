using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private KeyCode _key = KeyCode.F;
    [SerializeField] private float _damagePoints;
    [SerializeField] private float _healthPoints;
    [SerializeField] private float _timeDamage;
    [SerializeField] private float _timeRecharge;

    private Health _health;
    private Health _enemy;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.enabled = false;
        _slider.value = _slider.maxValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key) && _slider.value == _slider.maxValue)
            StartCoroutine(Use());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyNavigator enemy))
            _enemy = other.GetComponent<Health>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyNavigator enemy))
            _enemy = null;
    }

    private IEnumerator Use()
    {
        yield return VampirismDurationRoutine();
        yield return Recharge();
    }

    private IEnumerator VampirismDurationRoutine()
    {
        _sprite.enabled = true;
        int totalCalls = 10;
        float delayBetweenCalls = _timeDamage / totalCalls;
        float valuePerCall = _slider.maxValue / totalCalls;

        for (int i = 0; i < totalCalls; i++)
        {
            SuckOutLife();
            
            float targetValue = _slider.value - valuePerCall;
            float elapsed = 0f;
        
            while (elapsed < delayBetweenCalls)
            {
                _slider.value = Mathf.Lerp(_slider.maxValue - (valuePerCall * i), targetValue, elapsed / delayBetweenCalls);
                elapsed += Time.deltaTime;
                
                yield return null;
            }
        }
    }
    
    private IEnumerator Recharge()
    {
        _sprite.enabled = false;
        float speed = _slider.maxValue / _timeRecharge;
    
        while (_slider.value < _slider.maxValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value,_slider.maxValue, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void SuckOutLife()
    {
        if (_enemy != null)
        {
            _enemy.TakeDamage(_damagePoints);
            _health.Heal(_healthPoints);
        }
    }
}
