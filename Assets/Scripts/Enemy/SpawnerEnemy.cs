using System;
using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _position;
    
    private void Awake() =>
        SpawnNewEnemy();

    private void OnEnable() =>
        _enemy.Died += SpawnNewEnemy;

    private void OnDisable() =>
        _enemy.Died -= SpawnNewEnemy;

    private void SpawnNewEnemy() =>
        StartCoroutine(Create());

    private IEnumerator Create()
    {
        float spawnDelayInSecond = 5f;
        yield return new WaitForSeconds(spawnDelayInSecond);
        _enemy.transform.position = transform.position;
        _enemy.gameObject.SetActive(true);
        _enemy.Respawn();
    }
}
