using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private const string Jump = nameof(Jump);
    private const string Move = nameof(Move);
    private const string Fall = nameof(Fall);
    private readonly int JumpId = Animator.StringToHash(Jump);
    private readonly int MoveId = Animator.StringToHash(Move);
    private readonly int FallId = Animator.StringToHash(Fall);
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private int _mathRound = 3;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    private void Update() =>
        Fly();

    private void Fly()
    {
        bool isMove = false;
        bool isFall = false;
        bool isJump = false;
        
        if (Math.Round(_rigidbody.velocity.y, _mathRound)  > 0)
            isJump = true;
        else if (Math.Round(_rigidbody.velocity.y, _mathRound)  < 0)
            isFall = true;
        
        if (Math.Round(_rigidbody.velocity.y, _mathRound) == 0 && Input.GetAxis(Horizontal) != 0)
            isMove = true;
        
        _animator.SetBool(JumpId, isJump);
        _animator.SetBool(FallId, isFall);
        _animator.SetBool(MoveId, isMove);
    }
}
