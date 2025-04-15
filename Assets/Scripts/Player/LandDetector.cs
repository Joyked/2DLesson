using System;
using UnityEngine;

public class LandDetector : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private int _landedCount = 0;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
            _landedCount++;
        
        TransferState();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ground ground))
            _landedCount--;
        
        TransferState();
    }

    private void TransferState()
    {
        if(_landedCount > 0)
            _playerInput.TurnOnJump();
        else
            _playerInput.TurnOffJump();
    }
}
