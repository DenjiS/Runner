using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn
        && TryGetObject(out GameObject enemy))
        {
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
        }
    }

    private void SetEnemy(GameObject enemy, Vector2 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
