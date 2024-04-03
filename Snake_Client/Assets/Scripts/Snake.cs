using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    public float Speed { get { return _speed; } }

    [SerializeField] private int _playerLayer = 3;
    [SerializeField] private Skin _skin;
    [SerializeField] private Tail _tailPrefab;
    [SerializeField] private Text _name;
    [field: SerializeField] public Transform _head { get; private set; }
    [SerializeField] private float _speed = 2f;
    private Tail _tail;
    private Color _color;

    public void Init(int detailCount, Color color, string name, bool isPlayer = false)
    {
        if (isPlayer)
        {
            gameObject.layer = _playerLayer;
            var childrens = GetComponentsInChildren<Transform>();
            for (int i = 0; i < childrens.Length; i++)
            {
                childrens[i].gameObject.layer = _playerLayer;
            }
        }
        _name.text = name;
        _tail = Instantiate(_tailPrefab, transform.position, Quaternion.identity);
        _tail.Init(_head, _speed, detailCount, _playerLayer, isPlayer);
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

    public void Destroy(string clientID)
    {
        var detailPositions = _tail.GetDetailPositions();
        detailPositions.id = clientID;
        string json = JsonUtility.ToJson(detailPositions);
        MultiplayerManager.Instance.SendMessage("gameOver", json);
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
