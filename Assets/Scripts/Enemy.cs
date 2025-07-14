using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyShot))]
[RequireComponent(typeof(EnemyRotation))]
[RequireComponent(typeof(Attack))]
public class Enemy : MonoBehaviour
{

    
    private Rigidbody2D _rigidbody2D;
    private EnemyShot _enemyShot;
    private EnemyRotation _enemyRotation;
    private EnemyMover _mover;
    private Attack _attack;

    public event Action Died;

    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyShot = GetComponent<EnemyShot>();
        _enemyRotation = GetComponent<EnemyRotation>();
        _attack = GetComponent<Attack>();
        _mover = GetComponent<EnemyMover>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerBullet bullet))
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _enemyShot.StopShot();
            _enemyRotation.enabled = false;
            _attack.enabled = false;
            StartCoroutine(DestroyEnemy());
        }
    }

    public void Respawn()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _enemyRotation.enabled = true;
        _attack.enabled = true;
        _mover.ResetPosition();
    }
    
    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        Died?.Invoke();
    }
}
