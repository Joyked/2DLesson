using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<bool> SpacePressed;
    public event Action<bool> QPressed;
    
    private void Update()
    {
        SpacePressed?.Invoke(Input.GetKeyDown(KeyCode.Space));
        QPressed?.Invoke(Input.GetKeyDown(KeyCode.Q));
    }
}
