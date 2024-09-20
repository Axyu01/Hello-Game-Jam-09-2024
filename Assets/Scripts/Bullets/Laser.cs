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
        RaycastHit2D[] hitArray = null;
        hitArray= Physics2D.RaycastAll(transform.position, direction, _interactionMask.value);
        Debug.DrawRay(transform.position, direction, Color.red, 0.2f);
        foreach(RaycastHit2D hit in hitArray)
        {
            if (hit.collider.gameObject.TryGetComponent(out EntityBase entity))
            {
                entity.GetDmg(_dmg);
            }
            else
            {
                break;
            }
        }
        DestroyThisBullet();
    }
}
