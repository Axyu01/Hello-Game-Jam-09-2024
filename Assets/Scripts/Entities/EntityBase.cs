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
    bool _isBeingDestroyed = false;

    float _receivedDmgMultiplayer = 1f;
    float _debuffTimeLeft = 0f;
    public float DebuffTimeLeft { get { return _debuffTimeLeft; } }
    float _debuffTime = 0f;
    public float DebuffTime { get { return _debuffTime; } }
    public bool IsDebuffed { get { return _debuffTimeLeft > 0f; } }
    public virtual void GetDmg(float dmg)
    {
        if (dmg > 0f && _debuffTimeLeft > 0f)
        {
            dmg *= _receivedDmgMultiplayer;
        }
        _health -= dmg;
        if (_health <= 0f && _isBeingDestroyed == false)
        {
            _isBeingDestroyed = true;
            _health = 0f;
            DestroyThisEntity();
        }
        if(_health > _maxHealth)
            _health = _maxHealth;
    }
    protected void Start()
    {
        _health = _maxHealth;
    }
    public virtual void DestroyThisEntity()
    {
        Destroy(gameObject);
    }
    public static int EntitiesOverallCount()
    {
        return Entities.Count;
    }
    protected void FixedUpdate()
    {
        if (_debuffTimeLeft > 0f)
        {
            _debuffTimeLeft -= Time.fixedDeltaTime;
        }
        if (_debuffTimeLeft <= 0f)
        {
            _debuffTimeLeft = 0f;
            _receivedDmgMultiplayer = 1f;
        }
    }
    public void ApllyReceivedDmgDebuff(float multiplayer, float time)
    {
        _debuffTimeLeft = time;
        _receivedDmgMultiplayer = multiplayer;
        _debuffTime = time;
    }
}
