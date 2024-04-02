using UnityEngine;

public class Snake : MonoBehaviour
{
    public float Speed { get { return _speed; } }

    [SerializeField] private Skin _skin;
    [SerializeField] private Tail _tailPrefab;
    [field: SerializeField] public Transform _head { get; private set; }
    [SerializeField] private float _speed = 2f;
    private Tail _tail;
    private Color _color;

    public void Init(int detailCount, Color color)
    {
        _tail = Instantiate(_tailPrefab, transform.position, Quaternion.identity);
        _tail.Init(_head, _speed, detailCount);
        UpdateColors(color);
    }

    public void UpdateColors(Color color)
    {
        _color = color;
        _skin.SetColor(color);
        _tail.UpdateColors(color);
    }

    public void SetDetailCount(int detailCount)
    {
        _tail.SetDetailCount(detailCount);
        _tail.UpdateColors(_color);
    }

    public Color GetColor()
    {
        return _color;
    }

    public void Destroy()
    {
        _tail.Destroy();
        Destroy(gameObject);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _head.forward * Time.deltaTime * _speed;
    }

    public void SetRotation(Vector3 pointToLook)
    {
        _head.LookAt(pointToLook);
    }
}
