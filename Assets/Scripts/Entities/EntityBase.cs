using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    protected static List<EntityBase> Entities = new List<EntityBase>();
    protected void Awake()
    {
        Entities.Add(this);
    }
    protected void OnDestroy()
    {
        Entities.Remove(this);
    }
    [SerializeField]
    protected ActionBase _action;
    public ActionBase Action { get { return _action; } }
    protected float _health;
    [SerializeField]
    protected float _maxHealth;
    public float Health { get { return _health; } }
    public float MaxHealth { get { return _maxHealth; } }
    public void GetDmg(float dmg)
    {
        _health -= dmg;
        if (_health <= 0f)
        {
            DestroyThisEntity();
            _health = 0f;
        }
        if(_health > _maxHealth)
            _health = _maxHealth;
    }
    protected void Start()
    {
        _health = _maxHealth;
    }
    public void DestroyThisEntity()
    {
        Destroy(gameObject);
    }
    public static int EntitiesOverallCount()
    {
        return Entities.Count;
    }
}
