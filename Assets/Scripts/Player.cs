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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _action.TakeAction(MouseWorldPosition(), null);
        }
        _point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    Vector2 MouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    Vector2 _point = Vector2.zero;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_point, 0.3f);

    }
}
