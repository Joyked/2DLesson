using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Dier : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += DeletCharacter;
    }

    private void OnDisable()
    {
        _health.Died -= DeletCharacter;
    }

    private void DeletCharacter()
    {
        gameObject.SetActive(false);
    }
}
