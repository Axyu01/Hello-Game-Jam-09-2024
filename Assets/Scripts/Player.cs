using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingEntityBase
{
    public float MovementSpeed = 10f;

    void Update()
    {
        float speedX = Input.GetAxisRaw("Horizontal") * MovementSpeed;
        float speedY = Input.GetAxisRaw("Vertical") * MovementSpeed;
        Rigidbody.velocity = new Vector2 (speedX, speedY);
    }
}
