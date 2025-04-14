using System;
using UnityEngine;

class EnemyNavigator : MonoBehaviour, INavigator
{
    [SerializeField] private float _detectionRange;
    [SerializeField] private Transform[] _waypoints;
    
    private int _waypointsIndex = 0;
    private float _distansToPoint = 0.2f;
    private Transform _target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInput player))
            _target = player.transform;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInput player))
            _target = null;
    }

    public Vector2 GetDirection()
    {
        if (_target != null)
        {
            return (_target.transform.position - transform.position).normalized;
        }
        else
        {
            if (_waypoints.Length == 0) 
                return Vector2.zero;

            Transform targetPoint = _waypoints[_waypointsIndex];
            Vector2 direction = (targetPoint.position - transform.position).normalized;

            if ((transform.position - targetPoint.position).sqrMagnitude < _distansToPoint * _distansToPoint)
                _waypointsIndex = (_waypointsIndex + 1) % _waypoints.Length;
            
            return direction;
        }
    }
}