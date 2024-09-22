using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnActionEvent = new UnityEvent();
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
    float _actionCooldown = 1f;
    public float ActionCooldown { get { return _actionCooldown; } }
    [SerializeField]
    float _cooldownLeft = 0f;
    public float CooldownLeft { get { return _cooldownLeft; } }
    public bool OnCooldown { get { return _cooldownLeft > 0f; } }
    bool _hasStartedBeing = false;
    public bool HasStartedBeing { get { return _hasStartedBeing; } }
    public void TakeAction(Vector2 actionCursorPoint, EntityBase _targetedEntity = null)
    {
        if (OnCooldown || (_currentAmmo <= 0 && IsAmmoInfinite == false))
            return;
        if (_isAmmoInfinite == false)
        {
            _currentAmmo--;
        }
        OnAction(actionCursorPoint, _targetedEntity);
        OnActionEvent?.Invoke();
        _cooldownLeft = _actionCooldown;
    }
    protected abstract void OnAction(Vector2 actionCursorPoint,EntityBase _targetedEntity = null);
    protected void Start()
    {
        _hasStartedBeing = true;
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
