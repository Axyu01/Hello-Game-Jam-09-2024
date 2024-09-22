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
    bool _animate = false;
    [SerializeField]
    float _rayTravelTime;
    float _rayCurrentTravelTime;
    Vector2 _startPos = Vector2.zero;
    Vector2 _endPos = Vector2.zero;
    public void LateUpdate()
    {
        if( _animate)
        {
            _rayCurrentTravelTime -= Time.deltaTime;
            if(_rayCurrentTravelTime < 0f)
                DestroyThisBullet();
            transform.position = Vector2.Lerp(_endPos,_startPos, _rayCurrentTravelTime / _rayTravelTime);
        }
    }
    public override void Shoot(Vector2 direction, GameObject target = null)
    {
        _animate = true;
        _startPos = transform.position;
        RaycastHit2D[] hitArray = null;
        hitArray= Physics2D.RaycastAll(transform.position, direction, _range, _interactionMask.value);
        Debug.DrawRay(transform.position, direction, Color.red, 0.2f);
        _endPos = _startPos + direction * _range;
        foreach(RaycastHit2D hit in hitArray)
        {
            if (hit.collider.isTrigger)
                continue;
            {
                
            }
            if (hit.collider.gameObject.TryGetComponent(out EntityBase entity))
            {
                entity.GetDmg(_dmg);
                _endPos = hit.point;
            }
            else
            {
                _endPos = hit.point;
                break;
            }
        }
        _rayCurrentTravelTime = _rayTravelTime * (_endPos-_startPos).magnitude/_range;
        _rayTravelTime = _rayCurrentTravelTime;
    }
}
