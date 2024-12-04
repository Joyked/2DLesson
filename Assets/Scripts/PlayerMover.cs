using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private GroundCheck _groundCheck;
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
        _groundCheck.IsGround += ChangeLandingState;
    }

    private void OnDisable()
    {
        _groundCheck.IsGround -= ChangeLandingState;
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

    private void ChangeLandingState(bool isGround)
    {
        _isGround = isGround;
    }
}
