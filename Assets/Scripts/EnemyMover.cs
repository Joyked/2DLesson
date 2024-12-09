using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    
    private int _currentWaipoint = 0;
    private int _mathRound = 3;

    private void Update()
    {
        if (Math.Round(transform.position.x, _mathRound) == Math.Round(_waypoints[_currentWaipoint].position.x, _mathRound))
        {
            _currentWaipoint = (_currentWaipoint + 1) % _waypoints.Length;
            transform.eulerAngles = (Math.Abs(transform.rotation.y) == 1) ? Vector3.zero : Vector3.up * 180;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaipoint].position, _speed * Time.deltaTime);
    }
}
