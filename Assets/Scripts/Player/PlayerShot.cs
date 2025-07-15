using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class PlayerShot : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private bool _isShot;
    private Shooter _shooter;

    private void Awake() =>
        _shooter = GetComponent<Shooter>();

    private void OnEnable() =>
        _inputReader.QPressed += Shot;

    private void OnDisable()=>
        _inputReader.QPressed -= Shot;

    private void Update()
    {
        if(_isShot)
            _shooter.Shot();
    }

    private void Shot(bool isShoot) =>
        _isShot = isShoot;
}
