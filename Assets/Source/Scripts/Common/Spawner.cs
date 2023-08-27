using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _maxSecondsBetweenSpawn;
    [SerializeField] private float _minSecondsBetweenSpawn;

    private SpawnPoint[] _spawnPoints;
    private float _secondsBetweenSpawn;
    private float _elapsedTime = 0;

    private void Awake()
    {
        Initialize(_templates);

        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn
        && TryGetRandomObject(out GameObject enemy))
        {
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            SetEnemy(enemy, _spawnPoints[spawnPointNumber].transform.position);
        }
    }

    private void SetEnemy(GameObject enemy, Vector2 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
