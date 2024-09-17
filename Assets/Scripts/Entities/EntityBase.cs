using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    [SerializeField]
    protected ActionBase _action;
    protected float _health;
    [SerializeField]
    protected float _maxHealth;
    public float Health { get { return _health; } }
    public float MaxHealth { get { return _maxHealth; } }
    public void GetDmg(float dmg)
    {
        _health -= dmg;
        if(_health < 0 )
            _health = 0;
        if(_health > _maxHealth)
            _health = _maxHealth;
    }
}
