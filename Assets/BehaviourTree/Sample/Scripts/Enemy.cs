using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    Rigidbody2D _rb;

    public Vector2 MoveDir { get; set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    void Update()
    {
        _rb.velocity = MoveDir.normalized * _speed;
    }
}
