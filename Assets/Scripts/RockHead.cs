using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RockHead : MonoBehaviour
{
    private const string WakeUp = nameof(WakeUp);
    private readonly int WakeUpId = Animator.StringToHash(WakeUp);
    
    private Animator _animator;
    private bool isWakeUp;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Mover player))
        {
            isWakeUp = true;
            _animator.SetBool(WakeUpId, isWakeUp);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Mover player))
        {
            isWakeUp = false;
            _animator.SetBool(WakeUpId, isWakeUp);
        }
    }
}
