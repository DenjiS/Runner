using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _maxSecondsBetweenSpawn;
    [SerializeField][Min(0)] private float _minSecondsBetweenSpawn;

    private SpawnPoint[] _spawnPoints;
    private float _secondsBetweenSpawn;
    private float _elapsedTime = 0;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_maxSecondsBetweenSpawn < _minSecondsBetweenSpawn)
            _maxSecondsBetweenSpawn = _minSecondsBetweenSpawn;
    }
#endif

    private void Awake()
    {
        Initialize(_templates);
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        _secondsBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn
        && TryGetRandomObject(out GameObject enemy))
        {
            _elapsedTime = 0;
            _secondsBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
            Debug.Log(gameObject.name + _secondsBetweenSpawn);

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
