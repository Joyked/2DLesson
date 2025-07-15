using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string GameOwer = nameof(GameOwer);
    private readonly int JumpID = Animator.StringToHash(Jump);
    private readonly int GameOwerID = Animator.StringToHash(GameOwer);

    private Animator _animator;
    private InputReader _inputReader;
    private bool _jumpPressed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()=>
        _inputReader.SpacePressed += Up;

    private void OnDisable()=>
        _inputReader.SpacePressed -= Up;

    private void Update()=>
        _animator.SetBool(JumpID, _jumpPressed);
    
    public void PlayGameOwer()=>
        _animator.SetTrigger(GameOwerID);
    
    private void Up(bool buttonPressed) =>
        _jumpPressed = buttonPressed;
}
