using UnityEngine;

public class RockHead : MonoBehaviour
{
    private readonly int WakeUp = Animator.StringToHash("WakeUp");
    
    private Animator _animator;
    private bool isWakeUp = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMover player))
        {
            isWakeUp = true;
            _animator.SetBool(WakeUp, isWakeUp);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMover player))
        {
            isWakeUp = false;
            _animator.SetBool(WakeUp, isWakeUp);
        }
    }
}
