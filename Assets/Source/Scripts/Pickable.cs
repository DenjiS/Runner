using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
        {
            Interact(player);
        }

        Die();
    }

    protected abstract void Interact(Player player);

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
