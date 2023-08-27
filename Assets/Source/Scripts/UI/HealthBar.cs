using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HeartUI _heartTemplate;

    private readonly List<HeartUI> _hearts = new();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int crateHearts = value - _hearts.Count;

            for (int i = 0; i < crateHearts; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            int deleteHearts = _hearts.Count - value;

            for (int i = 0; i < deleteHearts; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        HeartUI newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<HeartUI>());
        newHeart.StartFill();
    }

    private void DestroyHeart(HeartUI heart)
    {
        _hearts.Remove(heart);
        heart.StartDestroy();
    }
}
