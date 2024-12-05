using System.Collections;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private readonly int AteCommand = Animator.StringToHash("Ate");
    
    private Animator _animator;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Eat()
    {
        StartCoroutine("Ate");
    }
    
    private IEnumerator Ate()
    {
        var animation = _animator.GetCurrentAnimatorStateInfo(0);
        _waitForSeconds = new WaitForSeconds(animation.length);
        _animator.SetTrigger(AteCommand);
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
