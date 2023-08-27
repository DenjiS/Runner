using UnityEngine;

public class EnemyBullet : Pickable
{
    [SerializeField] private int _damage;

    protected override void Interact(Player player)
    {
        player.ApplyDamage(_damage);
    }
}
