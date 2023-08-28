using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Transform _container;
    [SerializeField][Min(1)] private int _capacity;

    private readonly List<GameObject> _pool = new();

    protected virtual void Awake()
    {
        if (_templates.Any())
        {
            for (int i = 0; i < _capacity; i++)
            {
                int instanceNumner = i / _capacity;
                GameObject spawned = Instantiate(_templates[instanceNumner], _container.transform);
                
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
