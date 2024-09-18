using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingEntityBase
{
    [SerializeField]
    GameObject _weapon;
    public float MovementSpeed = 10f;

    void Update()
    {
        float speedX = Input.GetAxisRaw("Horizontal") * MovementSpeed;
        float speedY = Input.GetAxisRaw("Vertical") * MovementSpeed;
        Rigidbody.velocity = new Vector2 (speedX, speedY);

        var mouseWorldPosition = MouseWorldPosition();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _action.TakeAction(mouseWorldPosition, null);
        }
     
        _point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void LateUpdate()
    {
        var mouseWorldPosition = MouseWorldPosition();
        transform.rotation = Quaternion.LookRotation(Vector3.forward, (Vector3)mouseWorldPosition - transform.position);
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
    public void ChangeWeapon(GameObject prefab)
    {
        Destroy(_weapon);
        _weapon = Instantiate(prefab);
        _action = _weapon.GetComponentInChildren<ActionBase>();
    }
}
