using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public event Action<bool> IsGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Ground ground))
            IsGround?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Ground ground))
            IsGround?.Invoke(false);
    }
}
