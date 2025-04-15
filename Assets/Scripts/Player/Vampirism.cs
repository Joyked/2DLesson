using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _damagePoints;
    [SerializeField] private float _healthPoints;
    [SerializeField] private float _timeDamage;
    [SerializeField] private float _timeRecharge;

    private Health _health;
    private Health _enemy;
    private SpriteRenderer _sprite;
    private bool _isReady = true;
    private PlayerInput _playerInput;

    public event Action<float> OnCooldownProgress;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.enabled = false;
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput != null && _playerInput.IsVampirism())
            TryUseAbility();
    }

    public void TryUseAbility()
    {
        if (_isReady)
            StartCoroutine(UseAbilityRoutine());
    }

    private IEnumerator UseAbilityRoutine()
    {
        _isReady = false;

        yield return VampirismDurationRoutine();
        yield return RechargeRoutine();
        
        _isReady = true;
    }

    private IEnumerator VampirismDurationRoutine()
    {
        _sprite.enabled = true;
        int totalCalls = 10;
        float delayBetweenCalls = _timeDamage / totalCalls;
        float progressPerCall = 1f / totalCalls;

        for (int i = 0; i < totalCalls; i++)
        {
            SuckOutLife();

            float startProgress = 1f - (progressPerCall * i);
            float targetProgress = startProgress - progressPerCall;
            float elapsed = 0f;

            while (elapsed < delayBetweenCalls)
            {
                float currentProgress = Mathf.Lerp(startProgress, targetProgress, elapsed / delayBetweenCalls);
                OnCooldownProgress?.Invoke(currentProgress);
                elapsed += Time.deltaTime;

                yield return null;
            }
        }
    }

    private IEnumerator RechargeRoutine()
    {
        _sprite.enabled = false;
        float progress = 0f;
        float speed = 1f / _timeRecharge;

        while (progress < 1f)
        {
            progress = Mathf.MoveTowards(progress, 1f, speed * Time.deltaTime);
            OnCooldownProgress?.Invoke(progress);
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
}
