using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBullet enemy))
        {
            enemy.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent(out Destroyer destroyer))
        {
            gameObject.SetActive(false);
        }
    }
}
