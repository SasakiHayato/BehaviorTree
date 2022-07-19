using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUser : MonoBehaviour
{
    Rigidbody2D _rb;

    const int Speed = 5;
    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(x, y).normalized * Speed;
    }
}
