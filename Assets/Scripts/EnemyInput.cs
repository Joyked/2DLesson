using UnityEngine;

[RequireComponent(typeof(Mover))]
class EnemyInput : MonoBehaviour, INavigator
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _detectionRange;
    [SerializeField] private Transform _player;
    private int _waypointsIndex = 0;

    public Vector2 GetDirection()
    {
        if (_player != null && Vector2.Distance(transform.position, _player.position) < _detectionRange)
        {
            return (_player.position - transform.position).normalized;
        }
        else
        {
            if (_waypoints.Length == 0) 
                return Vector2.zero;

            Transform targetPoint = _waypoints[_waypointsIndex];
            Vector2 direction = (targetPoint.position - transform.position).normalized;

            if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
                _waypointsIndex = (_waypointsIndex + 1) % _waypoints.Length;
            
            return direction;
        }
    }
}