using System;
using UnityEngine;

public class Bootstarp : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    [SerializeField] private EnemyNavigator[] _enemys;
    

    private void Awake()
    {
        foreach (var enemy in _enemys)
            enemy.Initialized(_player);
    }
}
