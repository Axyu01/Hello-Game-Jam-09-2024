using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingEntityBase
{
    [SerializeField]
    GameObject _weapon;
    public float MovementSpeed = 10f;

    void LateUpdate()
    {
        float speedX = Input.GetAxisRaw("Horizontal") * MovementSpeed;
        float speedY = Input.GetAxisRaw("Vertical") * MovementSpeed;
        Rigidbody.velocity = new Vector2 (speedX, speedY);

        var mouseWorldPosition = MouseWorldPosition();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(_action != null)
               _action.TakeAction(mouseWorldPosition, null);
        }
     
        _point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
        if(_weapon != null)
            Destroy(_weapon);
        _weapon = Instantiate(prefab,transform.position,transform.rotation,transform);
        _action = _weapon.GetComponentInChildren<ActionBase>();
    }
    public void FullHeal()
    {
        _health = _maxHealth;
    }
    public override void DestroyThisEntity()
    {
        gameObject.SetActive(false);
        Rigidbody.isKinematic = true;
        Rigidbody.velocity = Vector3.zero;
        GameManager.Instance.EndGame();
    }
}
