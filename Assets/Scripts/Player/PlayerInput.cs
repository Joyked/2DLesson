using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlayerInput : MonoBehaviour, INavigator, IJumper
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    private LandDetector _landDetector;
    private bool _isGround;

    public void Initialize() => 
        _landDetector = GetComponentInChildren<LandDetector>();
    
    private void OnEnable()
    {
        _landDetector.Landed += TurnOnJump;
        _landDetector.Jumped += TurnOffJump;
    }

    private void OnDisable()
    {
        _landDetector.Landed -= TurnOnJump;
        _landDetector.Jumped -= TurnOffJump;
    }
    
    public Vector2 GetDirection() => 
        new Vector2(Input.GetAxis(Horizontal), 0f);

    public bool IsJump() => 
        Input.GetButtonDown(Jump) && _isGround;
    
    private void TurnOnJump() => 
        _isGround = true;
    
    private void TurnOffJump() => 
        _isGround = false;
}
