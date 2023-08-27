using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerBulletSpawner : Spawner
{
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private AudioSource _shotSound;

    protected override void Spawn(GameObject bullet)
    {
        SetEnemy(bullet, _spawnPoint.transform.position);
        _shotSound.Play();
    }
}
