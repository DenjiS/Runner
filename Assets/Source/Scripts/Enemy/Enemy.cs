using UnityEngine;

public class Enemy : Pickable
{
    [SerializeField] private int _damage;

    protected override void Interact(Player player)
    {
        player.ApplyDamage(_damage);
    }
}
