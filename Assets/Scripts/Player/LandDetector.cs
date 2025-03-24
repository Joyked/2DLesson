using System;
using UnityEngine;

public class LandDetector : MonoBehaviour
{
    public event Action Landed;
    public event Action Jumped;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Ground ground))
            Landed?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Ground ground))
            Jumped?.Invoke();
    }
}
