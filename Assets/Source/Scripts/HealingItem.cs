using UnityEngine;

public class HealingItem : Pickable
{
    [SerializeField] int _heal;

    protected override void Interact(Player player)
    {
        player.ApplyHealth(_heal);
    }
}
