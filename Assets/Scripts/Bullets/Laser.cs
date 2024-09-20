using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : BulletBase
{
    [SerializeField]
    Rigidbody2D _rigidbody;
    [SerializeField]
    float _dmg = 10;
    [SerializeField]
    float _range;
    [SerializeField]
    LayerMask _interactionMask;
    public override void Shoot(Vector2 direction, GameObject target = null)
    {
        Physics2D.RaycastAll(transform.position, direction, _interactionMask.value);
        DestroyThisBullet();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EntityBase entity))
        {
            entity.GetDmg(_dmg);
        }
    }
}
