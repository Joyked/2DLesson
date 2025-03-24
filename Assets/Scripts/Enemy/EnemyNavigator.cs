using UnityEngine;

[RequireComponent(typeof(Mover))]
class EnemyNavigator : MonoBehaviour, INavigator
{
    [SerializeField] private float _detectionRange;
    [SerializeField] private Transform[] _waypoints;

    private PlayerInput _player;
    private int _waypointsIndex = 0;

    public void Initialized(PlayerInput player) =>
        _player = player;
    
    public Vector2 GetDirection()
    {
        if (_player != null && Vector2.Distance(transform.position, _player.transform.position) < _detectionRange)
        {
            return (_player.transform.position - transform.position).normalized;
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