using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Tail _tailPrefab;
    [SerializeField] private Transform _head;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotateSpeed = 90f;
    private Tail _tail;

    public void Init(int detailCount)
    {
        _tail = Instantiate(_tailPrefab, transform.position, Quaternion.identity);
        _tail.Init(_head, _speed, detailCount);
    }

    public void Destroy()
    {
        _tail.Destroy();
        Destroy(gameObject);
    }

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
    }

    private void Move()
    {
        transform.position += _head.forward * Time.deltaTime * _speed;
    }

    private Vector3 _targetDirection = Vector3.forward;
    public void LookAt(Vector3 cursorPosition)
    {
        _targetDirection = cursorPosition - _head.position;
    }
}
