using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _templates;

    [SerializeField][Min(0)] private float _minSecondsBetweenSpawn;
    [SerializeField] private float _maxSecondsBetweenSpawn;

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
        && TryGetRandomObject(out GameObject @object))
        {
            _elapsedTime = 0;
            _secondsBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);

            Spawn(@object);
        }
    }

    protected void SetEnemy(GameObject @object, Vector2 spawnPoint)
    {
        @object.SetActive(true);
        @object.transform.position = spawnPoint;
    }

    protected virtual void Spawn(GameObject @object)
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        SetEnemy(@object, _spawnPoints[spawnPointNumber].transform.position);
    }
}
