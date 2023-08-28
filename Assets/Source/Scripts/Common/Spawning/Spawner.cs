using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField][Min(0)] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;

    private SpawnPoint[] _spawnPoints;
    private Coroutine _spawning;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _maxSpawnDelay = Mathf.Max(_minSpawnDelay, _maxSpawnDelay);
    }
#endif

    protected override void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        if ( _spawnPoints.Length == 0)
            _spawnPoints = new SpawnPoint[1] { gameObject.AddComponent<SpawnPoint>() };

        base.Awake();
    }

    private void OnEnable()
    {
        _spawning = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        _spawning = null;
    }

    protected virtual void SetObject(GameObject @object)
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        Vector2 spawnPoint = _spawnPoints[spawnPointNumber].transform.position;

        @object.SetActive(true);
        @object.transform.position = spawnPoint;
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            if (TryGetRandomObject(out GameObject @object))
            {
                SetObject(@object);
            }

            float delay = Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSeconds(delay);
        }
    }
}
