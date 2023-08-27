using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] SpawnPoint _spawnPoint;

    protected override void Spawn(GameObject @object)
    {
        SetEnemy(@object, _spawnPoint.transform.position);
    }
}
