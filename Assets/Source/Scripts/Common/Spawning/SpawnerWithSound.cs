using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpawnerWithSound : Spawner
{
    private AudioSource _shotSound;

    protected override void Awake()
    {
        _shotSound = GetComponent<AudioSource>();
        base.Awake();
    }

    protected override void Spawn(GameObject @object)
    {
        _shotSound.Play();
        base.Spawn(@object);
    }
}
