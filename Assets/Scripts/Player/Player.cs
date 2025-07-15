using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    private PlayerAnimator _animator;
    private PlayerMover _mover;

    public event Action GameOver;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            Died();
            StartCoroutine(Die());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
            Died();
    }

    public void Reset()
    {
        _counter.Reset();
        _mover.Reset();
    }
    
    private void Died()
    {
        _counter.Stop();
        _animator.PlayGameOwer();
        _mover.enabled = false;
    }

    private IEnumerator Die()
    {
        float second = 2f;
        yield return new WaitForSeconds(second);
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}
