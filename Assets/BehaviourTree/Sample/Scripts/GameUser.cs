using UnityEngine;

public class GameUser : MonoBehaviour
{
    [SerializeField] float _speed;

    Rigidbody2D _rb;

    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        _rb.velocity = new Vector2(x, y).normalized * _speed;
    }
}
