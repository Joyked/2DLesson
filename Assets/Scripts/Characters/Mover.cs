using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private INavigator _navigator;
    private IJumper _jumper;
    private Rigidbody2D _rigidbody;
    private int _mathRound = 3;
    
    public event Action TurnedRight;
    public event Action TurnedLeft;

    public void Awake()
    {
        _navigator = GetComponentInChildren<INavigator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_navigator is PlayerInput)
            _jumper = GetComponent<IJumper>();
    }

    private void Update()
    {
        if (_navigator != null)
        {
            Move();

            if (_jumper != null && _jumper.IsJump())
                Jump();
        }
    }

    private void Move()
    {
        Vector2 direction = _navigator.GetDirection();
        Vector3 position = transform.position + (Vector3)direction * _speed * Time.deltaTime;

        if (position.x < transform.position.x)
            TurnedRight?.Invoke();
        else if (position.x > transform.position.x)
            TurnedLeft?.Invoke();

        transform.position = position;
    }

    private void Jump() => _rigidbody.AddForce(new Vector2(0, _jumpForce));
}