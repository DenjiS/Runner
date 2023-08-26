using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private int _speed;
    
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
