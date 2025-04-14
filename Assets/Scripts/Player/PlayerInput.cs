using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlayerInput : MonoBehaviour, INavigator, IJumper
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    
    private LandDetector _landDetector;
    private bool _isGround;

    public Vector2 GetDirection() => 
        new Vector2(Input.GetAxis(Horizontal), 0f);

    public bool IsJump() => 
        Input.GetButtonDown(Jump) && _isGround;
    
    public void TurnOnJump() => 
        _isGround = true;
    
    public void TurnOffJump() => 
        _isGround = false;
}
