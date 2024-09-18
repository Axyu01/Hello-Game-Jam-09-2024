using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicBullet : BulletBase
{
    [SerializeField]
    Rigidbody2D _rigidbody;
    [SerializeField]
    float _velocity = 20;
    [SerializeField]
    float _dmg = 10;
    [SerializeField]
    float _destroyAfter = 5f;

    public override void Shoot(Vector2 direction, GameObject target = null)
    {
        Invoke("DestroyThisBullet", _destroyAfter);
        _rigidbody.velocity = direction.normalized * _velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out EntityBase entity))
        {
            entity.GetDmg(_dmg);
        }
        DestroyThisBullet();
    }
}
