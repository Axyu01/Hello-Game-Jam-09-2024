using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField]
    protected float _actionCooldown = 1f;
    [SerializeField]
    protected float _cooldownLeft = 0f;
    public bool OnCooldown { get { return _cooldownLeft > 0f; } }
    public void TakeAction(Vector2 actionCursorPoint, EntityBase _targetedEntity = null)
    {
        if (OnCooldown)
            return;
        OnAction(actionCursorPoint, _targetedEntity);
        _cooldownLeft = _actionCooldown;
    }
    protected abstract void OnAction(Vector2 actionCursorPoint,EntityBase _targetedEntity = null);
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
