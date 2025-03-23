using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeAttack;

    private Coroutine _coroutine;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Health>(out Health enemy))
            _coroutine = StartCoroutine(AttackEnemy(enemy));
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Health>(out Health enemy))
            StopCoroutine(_coroutine);
    }

    private IEnumerator AttackEnemy(Health enemy)
    {
        WaitForSeconds second = new WaitForSeconds(_timeAttack);

        while (true)
        {
            enemy.TakeDamage(_damage);
            yield return second;
        }
    }
}
