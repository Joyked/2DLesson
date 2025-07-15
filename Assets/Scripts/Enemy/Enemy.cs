using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyShot))]
[RequireComponent(typeof(EnemyRotation))]
[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour
{

    
    private Rigidbody2D _rigidbody2D;
    private EnemyShot _enemyShot;
    private EnemyRotation _enemyRotation;
    private EnemyMover _mover;
    private Shooter _shooter;

    public event Action Died;

    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyShot = GetComponent<EnemyShot>();
        _enemyRotation = GetComponent<EnemyRotation>();
        _shooter = GetComponent<Shooter>();
        _mover = GetComponent<EnemyMover>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _enemyShot.StopShot();
            _enemyRotation.enabled = false;
            _shooter.enabled = false;
            StartCoroutine(DestroyEnemy());
        }
    }

    public void Respawn()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _enemyRotation.enabled = true;
        _shooter.enabled = true;
        _mover.ResetPosition();
    }
    
    private IEnumerator DestroyEnemy()
    {
        float second = 3f;
        yield return new WaitForSeconds(second);
        gameObject.SetActive(false);
        Died?.Invoke();
    }
}
