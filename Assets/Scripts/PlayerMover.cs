using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private LandDetector _landDetector;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _landingHeight;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private bool _isGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

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

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f);
        transform.position += direction * _speed * Time.deltaTime;
        
        if (_isGround && Input.GetButtonDown(Jump))
            _rigidbody.AddForce(transform.up * _jumpForce);
        
        if (direction.x < 0)
            _spriteRenderer.flipX = true;
        else if (direction.x > 0)
            _spriteRenderer.flipX = false;
    }

    private void TurnOnJump()
    {
        _isGround = true;
    }

    private void TurnOffJump()
    {
        _isGround = false;
    }
}
