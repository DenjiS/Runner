using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyHealth(int health)
    {
        _health += Mathf.Clamp(health, 0, int.MaxValue);
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= Mathf.Clamp(damage, 0, int.MaxValue);
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Died?.Invoke();
    }
}
