using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float _secondReload;
    
    private EnemyMover _mover;
    private Attack _attack;
    
    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _attack = GetComponent<Attack>();
    }

    private void OnEnable() =>
        _mover.TookPosition += StartReload;

    private void OnDisable() =>
        _mover.TookPosition -= StartReload;

    public void StopShot()
    {
        StopCoroutine(Reload());
        _attack.isShot = false;
    }
    
    private void StartReload()
    {
        StartCoroutine(Reload());
        _attack.isShot = true;
    }
    
    private IEnumerator Reload()
    {
        WaitForSeconds second = new WaitForSeconds(_secondReload);

        while (true)
        {
            yield return second;
            _attack.Shot();
        }
    }
}
