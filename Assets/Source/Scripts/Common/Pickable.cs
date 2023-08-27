using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
        {
            Interact(player);
            gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent(out Destroyer destroyer))
        {
            gameObject.SetActive(false);
        }

    }

    protected abstract void Interact(Player player);
}
