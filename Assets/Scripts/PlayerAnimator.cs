using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string GameOwer = nameof(GameOwer);
    private readonly int JumpID = Animator.StringToHash(Jump);
    private readonly int GameOwerID = Animator.StringToHash(GameOwer);

    private Animator _animator;

    private void Awake() =>
        _animator = GetComponent<Animator>();

    private void Update()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);
        _animator.SetBool(JumpID, isJump);
    }
    
    public void PlayGameOwer()=>
        _animator.SetTrigger(GameOwerID);
}
