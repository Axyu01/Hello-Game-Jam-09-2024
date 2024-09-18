using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public abstract void Shoot(Vector2 direction, GameObject target = null);

    public void DestroyThisBullet()
    {
        Destroy(gameObject);
    }
}
