using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _step;

    private bool _isPosition = false;

    public event Action TookPosition;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _step);
        
        if (transform.position == _targetPosition.position && !_isPosition)
        { 
            TookPosition?.Invoke(); 
            _isPosition = true;
        }
    }
    
    public void ResetPosition() =>
        _isPosition = false;
}
