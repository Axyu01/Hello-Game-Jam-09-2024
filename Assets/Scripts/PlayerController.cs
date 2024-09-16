using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 10f;
    float _speedX, _speedY;
    Rigidbody2D _rb;
    void Start()
    {
        _rb= GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _speedX = Input.GetAxisRaw("Horizontal") * MovementSpeed;
        _speedY = Input.GetAxisRaw("Vertical") * MovementSpeed;
        _rb.velocity = new Vector2 (_speedX, _speedY);
    }
}
