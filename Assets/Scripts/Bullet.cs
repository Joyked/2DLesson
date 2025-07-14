using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Bullet> Destroyed; 

    private void FixedUpdate() =>
        transform.position += transform.up * _speed;

    private void OnTriggerEnter2D(Collider2D other) =>
        Destroyed?.Invoke(this);
}
