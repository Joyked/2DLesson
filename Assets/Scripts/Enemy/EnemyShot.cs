using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float _secondReload;
    
    private EnemyMover _mover;
    private Shooter _shooter;
    private Coroutine _startShot;
    
    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _shooter = GetComponent<Shooter>();
    }

    private void OnEnable() =>
        _mover.TookPosition += StartReload;

    private void OnDisable() =>
        _mover.TookPosition -= StartReload;

    public void StopShot() =>
        StopCoroutine(_startShot);
    
    private void StartReload() =>
        _startShot = StartCoroutine(Reload());
    
    private IEnumerator Reload()
    {
        WaitForSeconds second = new WaitForSeconds(_secondReload);
        bool isReloading = true;
        
        while (isReloading)
        {
            yield return second;
            _shooter.Shot();
        }
    }
}
