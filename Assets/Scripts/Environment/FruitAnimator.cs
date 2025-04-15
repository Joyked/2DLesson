using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FruitAnimator : MonoBehaviour, IVisitable
{
    private const string AteTrigger = "Ate";
    private readonly int _ateHash = Animator.StringToHash(AteTrigger);
    
    private Animator _animator;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void BeEaten() => 
        StartCoroutine(DisappearRoutine());

    private IEnumerator DisappearRoutine()
    {
        int numberLayer = 0;
        int animationNumber = _animator.GetCurrentAnimatorClipInfo(numberLayer).Length;
        _waitForSeconds = new WaitForSeconds(animationNumber);
        _animator.SetTrigger(_ateHash);
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
    
    public void Accept(IVisitor visitor) => 
        visitor.Visit(this);
}
