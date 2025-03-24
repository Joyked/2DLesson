using System;
using UnityEngine;

public class Bootstarp : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    [SerializeField] private EnemyNavigator[] _enemys;
    

    private void Awake()
    {
        _player.Initialize();

        foreach (var enemy in _enemys)
            enemy.Initialized(_player);
    }
}
