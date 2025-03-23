using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FruitAnimation : MonoBehaviour
{
    private const string Ate = nameof(Ate);
    private readonly int AteCommand = Animator.StringToHash(Ate);
    
    private Animator _animator;
    private WaitForSeconds _waitForSeconds;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void BeEaten()
    {
        StartCoroutine(Disappear());
    }
    
    private IEnumerator Disappear()
    {
        int numberLayer = 0;
        int animationNumber = _animator.GetCurrentAnimatorClipInfo(numberLayer).Length;
        _waitForSeconds = new WaitForSeconds(animationNumber);
        _animator.SetTrigger(AteCommand);
        
        yield return _waitForSeconds;
        
        gameObject.SetActive(false);
    }
}
