using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : BulletBase
{
    [SerializeField]
    Rigidbody2D _rigidbody;
    [SerializeField]
    float _velocity = 20;
    [SerializeField]
    float _correctionForce = 20;
    [SerializeField]
    float _dmg = 10;
    [SerializeField]
    float _appliedDmgDebuff = 2f;
    [SerializeField]
    float _debuffLength = 1f;
    [SerializeField]
    float _destroyAfter = 5f;
    GameObject _target;

    public override void Shoot(Vector2 direction, GameObject target = null)
    {
        Invoke("DestroyThisBullet", _destroyAfter);
        _rigidbody.velocity = direction.normalized * _velocity;
        _target = target;
    }
    public void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _velocity;
        if (_target != null)
        {
            _rigidbody.AddForce((_target.transform.position -transform.position).normalized * _correctionForce * _rigidbody.mass,ForceMode2D.Force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EntityBase entity))
        {
            entity.ApllyReceivedDmgDebuff(_appliedDmgDebuff, _debuffLength);
            entity.GetDmg(_dmg);
            DestroyThisBullet();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out EntityBase entity))
        {
            entity.ApllyReceivedDmgDebuff(_appliedDmgDebuff, _debuffLength);
            entity.GetDmg(_dmg);
        }
        DestroyThisBullet();
    }
}
