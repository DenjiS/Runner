using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _perObjectCapacity;
    [SerializeField] private Transform _container;

    private List<GameObject> _pool = new();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _perObjectCapacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        foreach (GameObject prefab in prefabs)
        {
            for (int i = 0; i < _perObjectCapacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }
    }

    protected bool TryGetRandomObject(out GameObject result)
    {
        List<GameObject> disabledObjects = _pool.Where(@object => @object.activeSelf == false).ToList();

        if (disabledObjects.Any())
        {
            int objectNumber = Random.Range(0, disabledObjects.Count());
            result = disabledObjects[objectNumber];

            return true;
        }
        else
        {
            result = null;

            return false;
        }
    }
}
