using UnityEngine;

public class BackgroundPlanet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Destroyer destroyer))
        {
            gameObject.SetActive(false);
        }
    }
}
