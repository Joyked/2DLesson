using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private readonly int Jump = Animator.StringToHash("Jump");
    private readonly int Move = Animator.StringToHash("Move");
    private readonly int Fall = Animator.StringToHash("Fall");
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private int _mathRound = 3;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isMove = false;
        bool isFall = false;
        bool isJump = false;
        
        if (Math.Round(_rigidbody.velocity.y, _mathRound)  > 0)
            isJump = true;
        else if (Math.Round(_rigidbody.velocity.y, _mathRound)  < 0)
            isFall = true;
        
        if (Math.Round(_rigidbody.velocity.y, 5) == 0 && Input.GetAxis(Horizontal) != 0)
            isMove = true;
        
        _animator.SetBool(Jump, isJump);
        _animator.SetBool(Fall, isFall);
        _animator.SetBool(Move, isMove);
    }
}
