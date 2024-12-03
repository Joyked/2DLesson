using System.Collections;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMover player)){}
            StartCoroutine(Ate());
    }

    private IEnumerator Ate()
    {
        var animation = _animator.GetCurrentAnimatorStateInfo(0);
        _animator.SetTrigger("Ate");
        yield return new WaitForSeconds(animation.length);
        gameObject.SetActive(false);
    }
}
