using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private int _currentWaipoint = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Math.Round(transform.position.x, 3) == Math.Round(_waypoints[_currentWaipoint].position.x, 3))
        {
            _currentWaipoint = (_currentWaipoint + 1) % _waypoints.Length;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaipoint].position, _speed * Time.deltaTime);
    }
}
