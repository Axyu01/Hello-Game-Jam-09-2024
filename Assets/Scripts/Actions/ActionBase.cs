using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class ActionBase : MonoBehaviour
{
    [Header("Ammo parameters")]
    [SerializeField]
    bool _isAmmoInfinite;
    public bool IsAmmoInfinite { get { return _isAmmoInfinite; } }
    [SerializeField]
    int _startAmmo = 120;
    public int StartAmmo { get { return _startAmmo; } }
    [SerializeField]
    int _currentAmmo = 0;
    public int CurrentAmmo { get { return _currentAmmo; } }
    [Header("Cooldown parameters")]
    [SerializeField]
    protected float _actionCooldown = 1f;
    [SerializeField]
    protected float _cooldownLeft = 0f;
    public bool OnCooldown { get { return _cooldownLeft > 0f; } }
    public void TakeAction(Vector2 actionCursorPoint, EntityBase _targetedEntity = null)
    {
        if (OnCooldown || (_currentAmmo <= 0 && IsAmmoInfinite == false))
            return;
        if (_isAmmoInfinite == false)
        {
            _currentAmmo--;
        }
        OnAction(actionCursorPoint, _targetedEntity);
        _cooldownLeft = _actionCooldown;
    }
    protected abstract void OnAction(Vector2 actionCursorPoint,EntityBase _targetedEntity = null);
    protected void Start()
    {
        _currentAmmo = _startAmmo;
    }
    protected void Update()
    {
        if (_cooldownLeft > 0f)
        {
            _cooldownLeft -= Time.deltaTime;
        }
        else
        {
            _cooldownLeft = 0f;
        }
    }
}
