using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooterAction : ActionBase
{
    [Header("General parameters")]
    [SerializeField]
    GameObject _bulletPrefab;
    [Header("Single bullet parameters")]
    [SerializeField]
    float _bulletRandomAngleDeviation = 0f;
    [Header("Multi bullet parameters")]
    [SerializeField]
    int _numberOfBullets = 1;
    [SerializeField]
    float _bulletsAngleSpread = 10f;

    protected override void OnAction(Vector2 actionCursorPoint, EntityBase _targetedEntity = null)
    {
        Vector2 forwardDirection = actionCursorPoint-(Vector2)transform.position;
        float angleDiff = _bulletsAngleSpread / _numberOfBullets;
        for (int i = 0; i < _numberOfBullets; i++)
        {
            Vector2 bulletDirection = Quaternion.Euler(0f, 0f, angleDiff * i - _bulletsAngleSpread * 0.5f + Random.Range(-_bulletRandomAngleDeviation/2f,_bulletRandomAngleDeviation/2f)) * forwardDirection;
            ShootBullet(_bulletPrefab, bulletDirection, _targetedEntity);
        }
    }
    void ShootBullet(GameObject prefab,Vector2 direction,EntityBase _targetedEntity = null)
    {
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity,GameManager.Instance.FightWorld.transform);
        if (bullet.TryGetComponent(out BulletBase bulletScript))
        {
            if (_targetedEntity != null)
            {
                bulletScript.Shoot(direction, _targetedEntity.gameObject);
            }
            else
            {
                bulletScript.Shoot(direction);
            }
        }
    }
    protected new void Update()
    {
        base.Update();
    }
}
