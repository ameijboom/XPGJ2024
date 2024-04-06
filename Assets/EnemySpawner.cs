using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private int _typeEnemy;
    public GameObject[] enemies;
    private bool _spawned;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (_renderer.isVisible && !_spawned)
        {
            SpawnEnemies(_typeEnemy);
        }
    }

    void SpawnEnemies(int type)
    {
        GameObject enemy = Instantiate(enemies[type], transform.position, Quaternion.identity);
        _spawned = true;
    }
}
