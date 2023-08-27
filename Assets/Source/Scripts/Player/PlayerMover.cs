using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pointerMoveSpeed;

    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    private void SetNextPosition(float speed)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + speed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPosition(_pointerMoveSpeed);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPosition(- _pointerMoveSpeed);
    }
}
