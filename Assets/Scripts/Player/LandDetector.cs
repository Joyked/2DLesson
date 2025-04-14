using System;
using UnityEngine;

public class LandDetector : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Ground ground))
            _playerInput.TurnOnJump();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Ground ground))
            _playerInput.TurnOffJump();
    }
}
